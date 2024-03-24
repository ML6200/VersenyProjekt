using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Infó_verseny
{
    class PoolClass
    {
        List<PearlClass> Allpearl = new List<PearlClass>();
        List<PearlClass> DisabledPearlsTemp = new List<PearlClass>();
        RobotClass Robot = new RobotClass();
        double maxroute = 0;
        double maxvalue = 0;
        List<PearlClass> resultlist = new List<PearlClass>();

        private double quotiensvalue = 0.353 ;

        public double RobotVelocity
        {
            get
            {
                return Robot.velocity;
            }

            set
            {
                if (value > 0)
                {
                    Robot.velocity = value;
                    maxroute = Robot.velocity * Robot.timelimit;
                }
            }
        }

        public double RobotTimelimit
        {
            get
            {
                return Robot.timelimit;
            }

            set
            {
                if (value > 0)
                {
                    Robot.timelimit = value;
                    maxroute = Robot.velocity * Robot.timelimit;
                }
            }
        }

        public double Quotiensvalue { get => quotiensvalue; set => quotiensvalue = value; }
        /// <summary>
        /// A Pool osztály konstruktora
        /// </summary>
        /// <param name="velocity"> A robot sebessége </param>
        /// <param name="timelimit"> A robot számára rendelkezésre álló idő </param>
        /// <param name="quotiens"> Egy olyan állandó, mely megmutatja hogy érdemes-e elindulnia a robotnak egy gyöngyért (javasolt: 0.353) </param>
        /// <param name="datafile"> A gyöngyök adatait tartalmazó file </param>
        public PoolClass(double velocity, double timelimit, double quotiens, string datafile)
        {
            RobotVelocity = velocity;
            RobotTimelimit = timelimit;
            Quotiensvalue = quotiens;

            Allpearl.Add(new PearlClass(0, 0, 0, 0));

            using (StreamReader reader = new StreamReader(datafile))
            {
                reader.ReadLine(); //Erre akkor van szükség, ha az első sort figyelmen kivül akarjuk hagyni

                while (!reader.EndOfStream)
                {
                    string[] temparray = reader.ReadLine().Split(';');
                    Allpearl.Add(new PearlClass(int.Parse(temparray[0]), int.Parse(temparray[1]), int.Parse(temparray[2]), int.Parse(temparray[3])));
                }
            }
        }

        public void Start()
        {
            CalcRoute(new List<PearlClass>(), maxroute, true);
            resultlist.Add(new PearlClass(0, 0, 0, 0));
        }

        private void CalcRoute(List<PearlClass> disabledpearls, double remainingroute, bool isFirst  = false)
        {
            var EnabledPearls = Allpearl.Except(disabledpearls);
            PearlClass currentpearl;
            if (isFirst)
            {
                EnabledPearls = Allpearl.Skip(1).Except(disabledpearls);
                EnabledPearls = Allpearl.Except(EnabledPearls);
                currentpearl = Allpearl[0];
            }
            else currentpearl = disabledpearls.Last();

            EnabledPearls = EnabledPearls.Where(x => x.Distance(currentpearl) < remainingroute - x.Distance(Allpearl[0]));  //A túl messze lévő gyögyök kiszűrése
            if (!isFirst) EnabledPearls = EnabledPearls.Where(x => x.Quotiens(currentpearl) > Quotiensvalue); //Túl kicsi ,,árértékarányú" gyöngyök kiszűrése
            
            if (EnabledPearls.Count() > 0) 
            {
                foreach (PearlClass item in EnabledPearls)
                {
                    disabledpearls.Add(item);

                    CalcRoute(disabledpearls,remainingroute - item.Distance(currentpearl)); //Rekurzió
                    disabledpearls.Remove(item);
                }
            }
            else
            {
                double disabledvalue = disabledpearls.Sum(x => x.value);
                if (maxvalue < disabledvalue)
                {
                    maxvalue = disabledvalue;
                    resultlist = disabledpearls.ToList();
                }
            }
            

        }

        public List<PearlClass> GetResultList()
        {
            return resultlist;
        }

        public double GetMaxValue()
        {
            return maxvalue;
        }
    }
}
