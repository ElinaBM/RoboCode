using Robocode;
using Robocode.Util;
using System;
using System.Drawing;

namespace EBM
{
    public class Usinsh : AdvancedRobot
    {

        //need to be able to scan to find enemy

        //need to fire when enemy detected

        //need to move away when enemy radar detects you

        //need to move away when bulet gets you (larger radius)
        //need to be able to detect where the radius is and constantly move out of it

        //search for enemy with lowest power to attack
        //ScannedRobotEvent getEnergy - this is in java need somethig similar

        //hide somehow??? shield??

        //Minimum requirement:
        //1. Scan with radar
        //2. Lock gun on enemy
        //3. Fire at enemy
        //4. Maybe do some super simple ducking from bulet

        double previousEnemyEnergy = 100; //innitial energy is 100
        double energyChange = 0.0;
        int directionIndication = 1; // 1 - move towards (in front) of enemy, -1 - back
        int scanDirection = 1;
        public override void Run()
        {
            //sets colors of robot
            SetColors(Color.Red, Color.Black, Color.Yellow, Color.DarkOrange, Color.WhiteSmoke);



            while (true)
            {
                TurnRadarRight(Double.PositiveInfinity); //Radar moves constantly
                //TurnRadarRight(60);
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent enemy)
        {
            //can search for weaker enemy? not sure if needed
            
            //SetTurnRight(enemy.Bearing + 90 - 30 * directionIndication);
            //SetTurnRadarRightRadians(Utils.NormalRelativeAngle(enemy.Bearing + Heading - RadarHeading));
            //SetTurnGunRightRadians(Utils.NormalRelativeAngle(enemy.Bearing + Heading - RadarHeading));
            scanDirection *= -1;

            TurnRadarRight(enemy.Bearing + Heading - RadarHeading);
            TurnGunRight(enemy.Bearing + Heading - GunHeading);
            SetTurnRight(enemy.Bearing + 90);

            //detect when robot has fired

            //energyChange = previousEnemyEnergy - enemy.Energy;
            //if (energyChange > 0 && energyChange <= 3)
            //{

            //}




            ////allign ourselves with enemy in front - not sure how this works...
            //SetTurnRight(evnt.Bearing + 90 - 30 * directionIndication);

            ////Asuming that enemy is firing at us/ More likely we are shooting at enemy

            //energyChange = previousEnemyEnergy - evnt.Energy;
            //previousEnemyEnergy = evnt.Energy;


            ////if original distance is less than 300 - move towards enemy, if more - move away, why??
            //if (energyChange > 0 && energyChange <= 3) //this is a hit
            //{
            //    directionIndication = (evnt.Distance <= 300 && directionIndication < 0) ? directionIndication : -directionIndication;
            //    SetAhead((evnt.Distance / 4 + 25) * directionIndication);
            //}



            ////to get my robot's energy??
            //var myEnergy = this.Energy;

            Fire(1);

        }

        int previousDirectionIndicator = 1;

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            if (previousDirectionIndicator == 1)
            {
                previousDirectionIndicator = -1;
                Ahead(40 * previousDirectionIndicator);
            }else
            {
                previousDirectionIndicator = 1;
                Ahead(40 * previousDirectionIndicator);
            }
        }

        public override void OnBulletHit(BulletHitEvent evnt)
        {
            //keep shooting same enemy
            
        }
    }
}
