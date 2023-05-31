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
                // todo add data

                //users
                User client = new User() { Name = "Niksa", Surname = "Jovic", Email = "niksa@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User agent = new User() { Name = "Mario", Surname = "Giordani", Email = "mario@gmail.com", Password = "pass1234", Role = Role.AGENT };
                db.Users.Add(client);
                db.Users.Add(agent);
                db.SaveChanges();

                //stay&eat
                TouristFacility facility1 = new TouristFacility() { Name = "Menza SCNS", Address = "Dr Sime Milosevica 4, Novi Sad", Type = PlaceType.RESTAURANT, Link= "http://www.scns.rs/sektori/sektor-ishrane/" };
                TouristFacility facility2 = new TouristFacility() { Name = "Dom Zivojin Culum", Address = "Bulevar Despota Stefana 5A, Novi Sad", Type = PlaceType.ACCOMODATION, Link = "http://www.scns.rs/sektori/sektor-smestaja/smestaj-studenata/studentski-domovi/studentski-dom-prof-zivojin-culum/" };
                TouristFacility facility3 = new TouristFacility() { Name = "Dom Nikola Tesla", Address = "Bulevar Despota Stefana 7A, Novi Sad", Type = PlaceType.ACCOMODATION, Link = "http://www.scns.rs/sektori/sektor-smestaja/smestaj-studenata/studentski-domovi/studentski-dom-nikola-tesla/" };
                db.TouristFacilities.Add(facility1);
                db.TouristFacilities.Add(facility2);
                db.TouristFacilities.Add(facility3);
                db.SaveChanges();

                //attractions
                Attraction attraction1 = new Attraction() { Name = "Katedrala", Address = "Trg Slobode, Novi Sad",  Description = "Cudesno lijepa rimokatolička crkva Imena Marijanog, u gradu poznata jednostavno kao Katedrala, podignuta na ovom mjestu još 1894. godine. Nekada se na ovom mjestu nalazila jedna mala i prilično skromna crkva iz 18. vijeka, dok danas ovdje stoji bez dileme jedan od simbola grada. Vjerovatno najimpresivniji dio na crkvi je toranj, visok čak 72 metra, sa satom koji gleda na sve četiri strane grade. Mada, čitava crkva je rađena u neogotskom stilu,\r\ndok su prozori ukrašeni peštanskim vitražima, čineći je jednako lijepom, kako izvana, tako i iznutra. Uz to, crkvu je besplatno kao poklon gradu projektovao Đerđ Molnar, a njegova bista se nalazi u niši ispod hora crkve.", Image = new byte[10] };
                Attraction attraction2 = new Attraction() { Name = "Muzej Vojvodine", Address = "Dunavska 35, Novi Sad", Description = "Smještan odmah pokraj Dunavskog parka, ovaj muzej predstavlja najveći kompleksni muzej u čitavoj Srbiji, čija kolekcija sadrži više od 6 000 eksponata iz arheologije, opšte istorije, istorije umetnosti i etnologije. Šetajući iz jedne prostorije u drugu, imaćete priliku da sagledate gotovo kompleksnu ljudsku istoriju, počev od najstarijih vremena, pa sve do današnjeg doba.", Image = new byte[10]};
                Attraction attraction3 = new Attraction() { Name = "Galerija Matice Srpske", Address = "Trg Galerija, Novi Sad", Description = "Ovo je najstarija književna, kulturna, ali i naučna institucija u Srbiji, osnovana još 1826. godine u Pešti, da bi 1864. godine bila preseljena u Novi Sad. Predstavlja prvu Maticu nekog od slavenskih naroda, te je svojim djelovanjem uticala na osnivanje Matica i kod drugih slavenskih naroda. Vjerovatno jedna od najveličanstvenih na našim prostorima, jer ćete u njoj imati priliku da vidite sva značajna dijela srpskih slikara kroz istoriju počevši od Uroša Predića, Save Šumanovića, Milan Konjović, Nadežde Petrović i mnogih drugih.", Image = new byte[10] };
                db.Attractions.Add(attraction1);
                db.Attractions.Add(attraction2);
                db.Attractions.Add(attraction3);
                db.SaveChanges();

                //trips
                Trip trip1 = new Trip() { Name = "Izlet Novim Sadom", Description = " Novi Sad je u neku ruku i grad slobode, zbog činjenice da su ga 1748. godine od države otkupili bogati građani, a ovaj trg kojeg vidite na fotografiji, nosi to ime. Osim svoje prostranosti i činjenice da predstavlja jedno od omiljenih mjesta svih lokalaca ovoga grada, trg slobode će vam otkriti dva veoma značajna spomenika Novog Sada. Grad se zaista može pohvaliti sa dosta dobrih opcija za sve smještajne kategorije.", Price = 5000, Image = new byte[10], Departure = "Banja Luka", Destination = "Novi Sad", StartDate = new DateTime().AddDays(30), EndDate = new DateTime().AddDays(31) };
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
                db.SaveChanges();
            }
        }
    }
}
