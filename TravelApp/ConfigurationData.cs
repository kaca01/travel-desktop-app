using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core;
using TravelApp.Core.Model;

namespace TravelApp
{
    public class ConfigurationData
    {
        public void PopulateDataBase()
        {
            using (var db = new TravelContext())
            {

                //users
                User client1 = new User() { Name = "Niksa", Surname = "Jovic", Email = "niksa@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User client2 = new User() { Name = "Ines", Surname = "Miletic", Email = "ines@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User client3 = new User() { Name = "Milica", Surname = "Milic", Email = "mica@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User client4 = new User() { Name = "Toma", Surname = "Tomic", Email = "toma@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User agent = new User() { Name = "Mario", Surname = "Giordani", Email = "mario@gmail.com", Password = "pass1234", Role = Role.AGENT };
                db.Users.Add(client1);
                db.Users.Add(client2);
                db.Users.Add(client3);
                db.Users.Add(client4);
                db.Users.Add(agent);
                db.SaveChanges();

                //stay&eat
                TouristFacility facility1 = new TouristFacility() { Name = "Student cafeteria SCNS", Address = "Dr Sime Milosevica 4, Novi Sad", Type = PlaceType.RESTAURANT, Link= "http://www.scns.rs/sektori/sektor-ishrane/", IsDeleted = false};
                TouristFacility facility2 = new TouristFacility() { Name = "Dorm Zivojin Culum", Address = "Bulevar Despota Stefana 5A, Novi Sad", Type = PlaceType.ACCOMODATION, Link = "http://www.scns.rs/sektori/sektor-smestaja/smestaj-studenata/studentski-domovi/studentski-dom-prof-zivojin-culum/", IsDeleted = true };
                TouristFacility facility3 = new TouristFacility() { Name = "Dorm Nikola Tesla", Address = "Bulevar Despota Stefana 7A, Novi Sad", Type = PlaceType.ACCOMODATION, Link = "http://www.scns.rs/sektori/sektor-smestaja/smestaj-studenata/studentski-domovi/studentski-dom-nikola-tesla/", IsDeleted = false };
                TouristFacility facility4 = new TouristFacility() { Name = "City tavern Stara Zanatlija", Address = "Slobodana Bursaća 20, Zrenjanin", Type = PlaceType.RESTAURANT, Link = "https://starazanatlija.rs/", IsDeleted = false };
                TouristFacility facility5 = new TouristFacility() { Name = "Kovac restaurant", Address = "Bagljaš Zapad 5, Zrenjanin", Type = PlaceType.RESTAURANT, Link = "https://kovaczrenjanin.rs/?_rstr_nocache=rstr1636478b708bbc85" , IsDeleted = false };
                TouristFacility facility6 = new TouristFacility() { Name = "Hotel Vojvodina", Address = "Trg slobode 3, Zrenjanin", Type = PlaceType.ACCOMODATION, Link = "https://hotel-vojvodina.rs/en/pocetna.html" , IsDeleted = false };
                TouristFacility facility7 = new TouristFacility() { Name = "Ečka Castle", Address = "Novosadska 7, Ečka", Type = PlaceType.ACCOMODATION, Link = "https://kastelecka.com/" , IsDeleted = false };      
                TouristFacility facility8 = new TouristFacility() { Name = "Zepter Hotel", Address = "Vrnjačka 12, Vrnjačka Banja", Type = PlaceType.ACCOMODATION, Link = "https://zepterhotels.com/destinations/vrnjacka-banja/?lang=en", IsDeleted = false };
                TouristFacility facility9 = new TouristFacility() { Name = "Hotel Tonanti", Address = "Svetog Save 2, Vrnjačka Banja", Type = PlaceType.ACCOMODATION, Link = "https://hoteltonanti.rs/en/home.html", IsDeleted = false };
                TouristFacility facility10 = new TouristFacility() { Name = "Restaurant Emilia", Address = "Heroja Čajke 3, Vrnjačka Banja", Type = PlaceType.RESTAURANT, Link = "https://vilaemilia.rs/restoran-emilia.php", IsDeleted = false };
                TouristFacility facility11 = new TouristFacility() { Name = "Restaurant 3 golubice", Address = "Bulevar srpskih ratnika 28, Vrnjačka Banja", Type = PlaceType.RESTAURANT, Link = "http://www.vilaljubica.rs/restoran-tri-golubice" , IsDeleted = false };

                db.TouristFacilities.Add(facility1);
                db.TouristFacilities.Add(facility2);
                db.TouristFacilities.Add(facility3);
                db.TouristFacilities.Add(facility4);
                db.TouristFacilities.Add(facility5);
                db.TouristFacilities.Add(facility6);
                db.TouristFacilities.Add(facility7);
                db.TouristFacilities.Add(facility8);
                db.TouristFacilities.Add(facility9);
                db.TouristFacilities.Add(facility10);
                db.TouristFacilities.Add(facility11);
                db.SaveChanges();

                //attractions
                Attraction attraction1 = new Attraction() { Name = "The cathedral", Address = "Trg Slobode, Novi Sad",  Description = "The marvelously beautiful Roman Catholic Church of Imen Marjan, known in the city simply as the Cathedral, was built on this site in 1894.There used to be a small and rather modest church from the 18th century on this place, and today it stands here without a doubt as one of the symbols of the city.Probably the most impressive part of the church is the tower, as high as 72 meters, with a clock that overlooks all four sides of the building.Although, the whole church is done in neo-gothic style, while the windows are decorated with stained glass from Pest, which makes it equally beautiful, both from the outside and from the inside. In addition, the church was designed by Đerđ Molnar for free as a gift to the city, and his bust is located in a niche under the choir of the church.", Image = new byte[10] };
                Attraction attraction2 = new Attraction() { Name = "Museum of Vojvodina", Address = "Dunavska 35, Novi Sad", Description = "Located right next to the Dunavski Park, this museum is the largest complex museum in all of Serbia, whose collection contains more than 6,000 exhibits from archaeology, general history, history of art and ethnology. Walking from one room to another, you will have the opportunity to see an almost complex human history, starting from the oldest times, until the present.", Image = new byte[10]};
                Attraction attraction3 = new Attraction() { Name = "Gallery of Matica Srpska", Address = "Trg Galerija, Novi Sad", Description = "This is the oldest literary, cultural, and scientific institution in Serbia, founded in 1826 in Pest, before being moved to Novi Sad in 1864. It represents the first Matica of one of the Slavic peoples, and with its actions it influenced the establishment of the Matica among other Slavic peoples as well. Probably one of the most important in our area, because in it you will have the opportunity to see all the significant works of Serbian painters throughout history, starting with Uroš Predić, Sava Šumanović, Milan Konjović, Nadežda Petrović and many others.", Image = new byte[10] };
                Attraction attraction4 = new Attraction() { Name = "Carska bara", Address = "Carska bara", Description = "The special nature reserve \"Carska bara\" lies between 3 cities: Belgrade, Novi Sad and Zrenjanin, in the confluence of the Tisa and Begeja rivers. If you haven't had the chance to visit this place yet, pick up the most important things and head to Zrenjanin! We are sure that you will like Carska bara very much and that you will enjoy it immensely. It represents a mosaic of bog-swamp, forest, meadow, steppe and salt marsh ecosystems with rich wildlife and habitats of many endemic and relict species. Also, pond lakes, which are located between 2 entities of the protected area, are of special importance.", Image = new byte[10] };
                Attraction attraction5 = new Attraction() { Name = "Beer museum", Address = "Vojvode Petra Bojovića 2, Zrenjanin", Description = "Did you know that Zrenjanin was and remains recognizable for its beer? Zrenjanin is known for the Days of Beer event, one of the largest in Serbia, which is visited by around half a million people. If you have decided to visit this city soon, listen to us and be sure to visit the Beer Museum. It is located just 800 meters from the center of Zrenjanin.", Image = new byte[10] };
                Attraction attraction6 = new Attraction() { Name = "Town house Zrenjanin", Address = "Trg Slobode 10, Zrenjanin", Description = "The former County Palace, and today's Town Hall, is the most beautiful and significant building in Zrenjanin. There is not a single significant historical event in the city that is not somehow connected with this building. The fact that this building is a frequent topic in local annals also speaks of its importance. The town hall is the seat of the city of Zrenjanin and the Central Banat district. Located on the city's Freedom Square, this building has been the most recognizable symbol on postcards of Zrenjanin for more than 100 years.", Image = new byte[10] };
                Attraction attraction7 = new Attraction() { Name = "Castle of culture", Address = "7. Jul, Vrnjačka Banja", Description = "Belimarković Castle, next to the Vrnjačka Church, is the oldest building in Vrnjačka Banja. It was built on a slope above the \"Topla Voda\" mineral water spring, modeled after the northern Italian Polish castles of the time. White marble from the Belimarković Maidan under the Goč mountain was used for the construction. The conceptual solution was given by the general's cousin, civil engineer Pavle Denić, with the design and supervision of engineer Frac Winter, in the period from 1888 to 1894, with most of the works completed as early as 1889.", Image = new byte[10] };
                Attraction attraction8 = new Attraction() { Name = "Source of mineral water Slatina", Address = "Slatinski venac, Vrnjačka Banja", Description = "Slatina is one of the sources of mineral water that contributed a lot to the development of spa tourism in Vrnjačka Banja.\r\nThe Slatina spring is located on the right side of the promenade, next to the Lipovačka river, and represents the real gem of Vrnjačka Banja. A quiet corner for all those who are curious, as well as for those who want to feel the healing power of Vrnjačka Banja, it has greatly contributed to the development of tourism in this part of Serbia, and it is up to you to feel the magic it exudes.", Image = new byte[10] };
                Attraction attraction9 = new Attraction() { Name = "Source \"Topla voda\"", Address = "Topla voda, Vrnjačka Banja", Description = "Located in the very heart of Vrnjačka Banja, the Hot Spring is one of the central places in one of the pearls of spa tourism in Serbia. Walking through the beautiful Vrnjak park, all roads lead you to this spa spring that exudes the spirit it carries throughout the history of its existence. The mere thought that the dating of this source goes back to prehistoric times tells us the value of what our nature offers to the curious traveler who wants to relax and feel the charms of soothing spa air and healing water. The mineral water from this source gives many positive results in the treatment, and above all, in the prevention of certain diseases, among which we can single out diabetes, which today belongs to the list of diseases of the modern age.", Image = new byte[10] };
                db.Attractions.Add(attraction1);
                db.Attractions.Add(attraction2);
                db.Attractions.Add(attraction3);
                db.Attractions.Add(attraction4);
                db.Attractions.Add(attraction5);
                db.Attractions.Add(attraction6);
                db.Attractions.Add(attraction7);
                db.Attractions.Add(attraction8);
                db.Attractions.Add(attraction9);
                db.SaveChanges();

                //trips
                Trip trip1 = new Trip() { Name = "Trip to Novi Sad", Description = "In a way, Novi Sad is also the city of freedom, due to the fact that in 1748 it was bought from the state by rich citizens, and this square you see in the photo bears that name. Apart from its spaciousness and the fact that it is one of the favorite places of all the locals of this city, Freedom Square will reveal two very important monuments of Novi Sad. The city can really boast of a lot of good options for all accommodation categories.", Price = 5000, Image = new byte[10], Departure = "Banja Luka", Destination = "Novi Sad", StartDate = DateTime.Now.AddDays(30), EndDate = DateTime.Now.AddDays(31), IsDeleted = false };
                Trip trip2 = new Trip() { Name = "Trip to Zrenjanin", Description = "Coming to Zrenjanin today, you are coming to a city of multiculturalism, multiconfessionalism and inter-ethnic tolerance, you are coming to a city of culture, art, sports, a city of bridges, a city of young people and a city of strong economic momentum. Zrenjanin can be recognized by world-renowned choirs, the National Museum or the Historical Archive, the best in Serbia in 2007, but also by the sports names of Dejan Bodiroga, the Grbić brothers, Snežana Perić, Ivan Lenđer, Ivana Španović, Jovana Brakočević or Maja Ognjenović.", Price = 8000, Image = new byte[10], Departure = "Niš", Destination = "Zrenjanin", StartDate = DateTime.Now.AddDays(20), EndDate = DateTime.Now.AddDays(21), IsDeleted = false };
                Trip trip3 = new Trip() { Name = "Trip to Vrnjacka Banja", Description = "Vrnjačka Banja is a more developed Serbian spa, with a long spa tradition, a spa where entire generations have come for their \"dose of health\", and yet it is much more than that, much more than a spa and much more than \"just\" a spa.\r\nSince the opening of the first spa season, the people of Vrnjačka Banja have strived to offer their guests more than the already impressive 7 mineral springs and other healing natural factors.", Price = 5500, Image = new byte[10], Departure = "Kragujevac", Destination = "Vrnjačka Banja", StartDate = DateTime.Now.AddDays(35), EndDate = DateTime.Now.AddDays(36), IsDeleted = false };
                List<TouristFacility> facilities = new List<TouristFacility>
                {
                    facility1,
                    facility2,
                    facility3
                };
                trip1.FacilityList = facilities;
                List<Attraction> attractions = new List<Attraction>
                {
                    attraction1,
                    attraction2,
                    attraction3
                };
                trip1.Attractions = attractions;
                db.Trips.Add(trip1);

                facilities = new List<TouristFacility>
                {
                    facility4,
                    facility5,
                    facility6,
                    facility7
                };
                trip2.FacilityList = facilities;
                attractions = new List<Attraction>
                {
                    attraction4,
                    attraction5,
                    attraction6
                };
                trip2.Attractions = attractions;
                db.Trips.Add(trip2);

                facilities = new List<TouristFacility>
                {
                    facility8,
                    facility9,
                    facility10,
                    facility11
                };
                trip3.FacilityList = facilities;
                attractions = new List<Attraction>
                {
                    attraction7,
                    attraction8,
                    attraction9
                };
                trip3.Attractions = attractions;
                db.Trips.Add(trip3);
                db.SaveChanges();

                //purchases and reservations
                Transaction reservation1 = new Transaction() { User = client1, Trip = trip1, Type = TransactionType.RESERVATION, IsDeleted=false };
                Transaction purchase1 = new Transaction() { User = client2, Trip = trip1, Type = TransactionType.PURCHASE, IsDeleted = false };
                Transaction reservation2 = new Transaction() { User = client2, Trip = trip2, Type = TransactionType.RESERVATION, IsDeleted=false };
                Transaction purchase2 = new Transaction() { User = client1, Trip = trip2, Type = TransactionType.PURCHASE , IsDeleted = false };
                Transaction reservation3 = new Transaction() { User = client1, Trip = trip3, Type = TransactionType.RESERVATION , IsDeleted = false };
                Transaction purchase3 = new Transaction() { User = client3, Trip = trip3, Type = TransactionType.PURCHASE , IsDeleted = false };
                Transaction reservation4 = new Transaction() { User = client2, Trip = trip3, Type = TransactionType.RESERVATION , IsDeleted = false };
                Transaction purchase4 = new Transaction() { User = client4, Trip = trip3, Type = TransactionType.PURCHASE , IsDeleted = false };
                db.Transactions.Add(reservation1);
                db.Transactions.Add(purchase1);
                db.Transactions.Add(reservation2);
                db.Transactions.Add(purchase2);
                db.Transactions.Add(reservation3);
                db.Transactions.Add(purchase3);
                db.Transactions.Add(reservation4);
                db.Transactions.Add(purchase4);
                db.SaveChanges();
            }
        }
    }
}
