using RunSafe.Models;
using System;
using System.Linq;

namespace RunSafe.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AssetContext context)
        {
            context.Database.EnsureCreated();

            //Look for the customer table to check if DB has been seeded
            if (context.Person.Any())
            {
                return; //DB has already been seeded
            }

            //create the people
            var Persons = new Person[]
            {
                new Person {/* ID 1 */firstname="Phil",lastname="Munro",email="phil.munro@gmail.com",MobileNumber="07769227425"},
                new Person {/* ID 2 */firstname="Tamzin",lastname="Munro",email="tamzin.munro@gmail.com",MobileNumber="077740366678"}
            };
            foreach (Person Person_i in Persons)
            {
                context.Person.Add(Person_i);
            }
            context.SaveChanges();


            //create the pings
            var Pings = new Ping[]
            {
                new Ping {/* ID 1 */datetime_logged= new DateTime(2017,04,01,10,50,21),datetime_stored= new DateTime(2017,04,01,10,50,35),latitude=57.3395583,longtitude=-5.6521707,signal=25,battery=75},
                new Ping {/* ID 1 */datetime_logged= new DateTime(2017,04,01,10,51,20),datetime_stored= new DateTime(2017,04,01,10,51,30),latitude=57.3391226,longtitude=-5.6513352,signal=20,battery=75},
                new Ping {/* ID 1 */datetime_logged= new DateTime(2017,04,01,10,52,25),datetime_stored= new DateTime(2017,04,01,10,52,37),latitude=57.3388575,longtitude=-5.651328,signal=20,battery=74},
                new Ping {/* ID 1 */datetime_logged= new DateTime(2017,04,01,10,53,27),datetime_stored= new DateTime(2017,04,01,10,53,30),latitude=57.3386835,longtitude=-5.6513582,signal=20,battery=74},
                new Ping {/* ID 1 */datetime_logged= new DateTime(2017,04,01,10,54,22),datetime_stored= new DateTime(2017,04,01,10,54,25),latitude=57.3384077,longtitude=-5.6512489,signal=20,battery=74},
                new Ping {/* ID 1 */datetime_logged= new DateTime(2017,04,01,10,55,23),datetime_stored= new DateTime(2017,04,01,10,55,28),latitude=57.3380538,longtitude=-5.651163,signal=20,battery=74}

            };
            foreach (Ping Ping_i in Pings)
            {
                context.Ping.Add(Ping_i);
            }
            context.SaveChanges();
        }
    }
}
