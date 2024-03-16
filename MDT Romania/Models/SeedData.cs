using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MDT_Romania.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<ApplicationDbContext>>()))
            {
                // Verificam daca in baza de date exista cel putin un rol
                // insemnand ca a fost rulat codul 
                // De aceea facem return pentru a nu insera rolurile inca o data
                // Acesta metoda trebuie sa se execute o singura data 
                

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                    new Category { Title = "Crime Împotriva unei Persoane" },
                    new Category { Title = "Crime Împotriva unei Proprietăți" },
                    new Category { Title = "Crime Împotriva Integritatii Fizice" },
                    new Category { Title = "Crime Împotriva Demnității Publice" },
                    new Category { Title = "Infractiuni de audienta" },
                    new Category { Title = "Crime Împotriva Liniștii Publice" },
                    new Category { Title = "Crime Împotriva Siguranței Publice" },
                    new Category { Title = "Traffic Violation" },
                    new Category { Title = "Controlul Armelor și Echipamentului Mortal" },
                    new Category { Title = "Legislaţia rutieră" },
                    new Category { Title = "State Code Violations" },
                     new Category { Title = "Prevederile Condamnării" }
                    );
                    context.SaveChanges();

                }
                if (!context.Crimes.Any())
                {
                    context.Crimes.AddRange(
                         new Crime{Name="Asalt",Description= "Cauzarea sau amenințarea cu o vătămare iminentă folosind o armă alba.",Fine= 2000,Jail= 5, CategoryId = 1},
                         new Crime{Name="Amenințări criminale",Description= "Comunicarea intenției de a agresa sau ucide pe x sau un apropiat al lui, plasând pe x într-o stare justificată de frică.",Fine= 500,Jail= 9, CategoryId = 1},
                         new Crime{Name="Asalt cu o armă mortală",Description= "Cauzarea sau amenințarea cu o vătămare iminentă folosind o armă sau orice alt obiect de natura sa comunice intenția.",Fine= 3000,Jail= 2, CategoryId = 1},
                         new Crime{Name="Omor",Description= "O persoană care omoară pe altcineva cu intentie.intenție premeditată (un plan de a comite crima)intentie imediata (decide pe loc sa il omoare - decizie constienta)",Fine= 3000,Jail= 2, CategoryId = 1},
                         new Crime{Name="Omor din culpă",Description= "Omor neintenționat, nepremeditat si nici dorit de faptuitor. Prin neglijență criminală sau printr-un accident/ incident.",Fine= 2000,Jail= 3, CategoryId = 1},
                         new Crime{Name="Tentativă de omor",Description= "încercare deliberata și intenționata de a comite omor, nereusita.",Fine= 1500,Jail= 5, CategoryId = 1},
                         new Crime{Name="Reținere ilegală",Description= "Reținerea unei pers fără consimțământul lor, pentru mai puțin de o oră. Arestarea ilegală a unui cetățean.",Fine= 300,Jail= 9, CategoryId = 1},
                         new Crime{Name="Răpire",Description= "Deținerea unei pers fara consimțământul acesteia,cu intenția premeditată de a face acest lucrusau/si pentru mai mult de o orăsau/si pentru răscumpărare de orice fel.",Fine= 1500,Jail= 5, CategoryId = 1},
                         new Crime{Name="Violență reciprocă",Description= "Luptă intre doi/mai multi indivizi într-o zonă publica.",Fine= 500,Jail= 9, CategoryId = 1},
                         new Crime{Name="Vătămare corporală",Description= "Folosirea violenței sau a forței ilegale pentru a cauza daune fizice unei alte persoane.",Fine= 500,Jail= 2, CategoryId = 1},
                         new Crime{Name="Vătămare corporală gravă",Description= "Vatamare corporala ce duce la zile de spitalizare/ingrijiri medicale prelungite. Dacă se foloseste o armă pt comitere, făptuitorul primește sentința maximă.",Fine= 1000,Jail= 3, CategoryId = 1},
                         new Crime{Name="Tortură",Description= "Provocarea în mod intenționat durere și suferințe extreme unei persoane. Inclusiv in scop de răzbunare, extorcare, convingere sau pentru orice scop sadic.",Fine= 2000,Jail= 4, CategoryId = 1},
                         new Crime{Name="Crima prin intermediul vehicului",Description= "O persoana care omoara o alta persoana cu autovehiculul ",Fine= 2000,Jail= 1, CategoryId = 1},


                         new Crime { Name = "Incendiere", Description = "Declanșare/ajutor/sfat/facilitare a unei incendieri a oricarei structură/teren de pădure/proprietate. Inclusiv prin accidente sau neglijență (culpa).", Fine = 1500, Jail = 6, CategoryId = 2 },
                         new Crime { Name = "Pătrunderea într-o zonă privată", Description = "Pătrunderea pe proprietatea unei persoane, fără permisiunea exprimată sau scrisă. Refuz sa plece la solicitarea proprietarului.", Fine = 300, Jail = 6, CategoryId = 2 },
                         new Crime { Name = "Pătrunderea într-o zonă restricționată", Description = "Pătrundere fără autorizație corespunzătoare, în orice secțiune restrânsă personalului neautorizat. Secțiune restrânsă într-o clădire guvernamentală", Fine = 1000, Jail = 4, CategoryId = 2 },
                         new Crime { Name = "Pătrunderea prin efracție", Description = "Pătrunderea pe proprietatea închisă/restrânsă a altuia, fără permisiunea acestuia, cu intenția să comită o infracțiune.", Fine = 900, Jail = 7, CategoryId = 2 },
                         new Crime { Name = "Șantaj", Description = "Fapta de a intimida sau a influența pe x să furnizeze/sa nu furnizeze/să predea proprietăți sau servicii. Fapta de a folosi autoritatea sau influenta pentru a impune acțiunea unei alte persoane. Fapta de a utiliza informații privilegiate/ false pentru a intimida pe altcineva.", Fine = 1200, Jail = 0, CategoryId = 2 },
                         new Crime { Name = "Inselaciune", Description = "Inducere in eroare a unei persoane, cu intentie, prin cuvinte/ comportament/afirmații false/ ascunderea a ceea ce ar fi trebuit să fie dezvăluitpentru a realiza un profit material/a obtine foloase.", Fine = 1100, Jail = 0, CategoryId = 2 },
                         new Crime { Name = "Talharie", Description = "Actiunea de a lua proprietatea din posesia cuiva, împotriva voinței sale, prin forță sau frică - amenintari criminale/ vătămare corporală.", Fine = 2000, Jail = 2, CategoryId = 2 },
                         new Crime { Name = "Jaf", Description = "La aceasta pedeapta suspectul nu avea o arma de foc asupra sa", Fine = 1500, Jail = 1, CategoryId = 2 },
                         new Crime { Name = "Jaf armat", Description = "La aceasta pedeapta este inclus automat posesisa unei arme de foc", Fine = 3000, Jail = 1, CategoryId = 2 },
                         new Crime { Name = "Furt", Description = "Pe langa furt, se adauga si Jaf", Fine = 1000, Jail = 2, CategoryId = 2 },
                         new Crime { Name = "Furt Inalt", Description = "Pe langa furt, se adauga si Jaf/ jaf armat", Fine = 2500, Jail = 10, CategoryId = 2 },
                         new Crime { Name = "Furtul unui autovehicul", Description = "Furtul oricărui vehicul, indiferent de valoare.", Fine = 1000, Jail = 7, CategoryId = 2 },
                         new Crime { Name = "Furtul unei arme de foc", Description = "Furtul oricărei arme de foc, indiferent de valoarea acesteia/dacă este înregistrată.", Fine = 1500, Jail = 10, CategoryId = 2 },
                         new Crime{Name="Primirea unui bun furat",Description= "Cumpararea/primirea cu bună știință a oricarui bun care a fost furat sau care a fost obținut în orice mod care constituie talharie sau șantaj.", Fine = 500, Jail = 6, CategoryId = 2},
                         new Crime { Name = "Vandalism", Description = "Distrugere prin orice mijloace de proprietati.", Fine = 800, Jail = 3, CategoryId = 2 },

                          new Crime { Name = "Eroism", Description = "O persoană care ia legea în mâinile sale, care acţionează după propriile idei", Fine = 1000, Jail = 1, CategoryId = 3 },
                          new Crime { Name = "Hărţuire", Description = "Urmarirea, in mod repetat, a unei persoane, cauzandu-i acestuia o temere. Apeluri/comunicari directe/ prin persoane interpuse ce ,prin continut sau modalitatea de transmitere, sunt de natura sa creeze persoanei o temere.", Fine = 300, Jail = 9, CategoryId = 3 },
                          new Crime{Name="Hărţuire sexuală",Description= "Atingerea cuiva cu scopul de a întreţine relaţii sexuale sau cu sugestivitate la acestea,indifferent de sexul persoanei.Atingerea altei persoane în zone indecente, fără voia ei.", Fine = 700, Jail = 9, CategoryId = 3},
                             new Crime { Name = "Viol", Description = "Actiunea de a forta prin orice mijloace o altă persoana sau a profita de incapacitatea acesteia de a se apara, in scopul de a întreține relații sexuale.", Fine = 5000, Jail = 3, CategoryId = 3 },
                             new Crime { Name = "Prostituţie", Description = "Intretinerea de raporturi sexuale cu diferite persoane contra unei sume de bani. Se aplică și la clienții acestor persoane, care fac uz de prostituție.", Fine = 1050, Jail = 10, CategoryId = 3 },
                             new Crime { Name = "Proxenetism", Description = "Orice persoană care solicită, face publicitate, ajută sau oferă transport ori supervizează persoane implicate în prostituţie şi obţine o parte din suma câştigată in urma actului sexual comite proxenetism.", Fine = 3500, Jail = 1, CategoryId = 3 },

                              new Crime { Name = "Acoperirea feței ", Description = "Purtare de masca de natura sa acopere toata fata, fara un temei legal.", Fine = 500, Jail = 3, CategoryId = 4 },
                             new Crime { Name = "Comportament indecent", Description = "Comportament inadecvat, sexual sau scarbos în orice loc public// deschis/expus publicului. Injurii/ semne obscene in public.", Fine = 250, Jail = 7, CategoryId = 4 },
                             new Crime { Name = "Refuzul legitimarii la solicitarea unui politist", Description = "Refuz ce implica o legitimare fortata", Fine = 1500, Jail = 1, CategoryId = 4 },
                             new Crime{Name="Injurii adresate unui functionar public",Description= "Functionar public = politist, medic, avocat - in timpul serviciului se aplica sanctiunea de cate ori se savarseste izolat fapta", Fine = 100, Jail = 8, CategoryId = 4},
                             new Crime { Name = "Incercare dare de mita", Description = "Actiunea de a da mita.", Fine = 300, Jail = 7, CategoryId = 4 },
                             new Crime{Name="Urmărirea unei persoane fără aprobare / împuternicire",Description = "Urmarirea unei persoane prin orice mijloace(masina, prin persoane interpuse, etc) fara a avea un temei legal.",Fine = 500,Jail = 9, CategoryId = 4},
                             new Crime{Name="Obstrucționarea justitiei",Description= "1. O pers care impiedica voit un angajat guvernamental din a efectua acte de justitie.",Fine = 1500,Jail = 0, CategoryId = 4},
                             new Crime{Name="Rezistență asupra unui ofițer",Description= "Rezistență la arest depusa prin eforturi fizice.",Fine= 2500,Jail= 8, CategoryId = 4},
                             new Crime{Name="Evadarea din custodie",Description= "Evadare din celule/ din custodia politiei/ ofiterului de eliberare conditionata.",Fine= 3000,Jail= 6, CategoryId = 4},
                             new Crime { Name = "Evadare din inchisoare", Description = "Evadare din penitenciar.", Fine = 10000, Jail = 4, CategoryId = 4 },
                             new Crime { Name = "Complice evadare", Description = "Orice persoana care ajuta/ ascunde o alta pt a evada.", Fine = 2500, Jail = 1, CategoryId = 4 },
                             new Crime { Name = "Trafic de persoane", Description = "Vanzare de persoane/ trafic de carne vie", Fine = 5000, Jail = 8, CategoryId = 4 },
                             new Crime { Name = "Abuz/Folosire necorespunzatoare a liniei de urgenta", Description = "Apel servicii fara un temei (o urgenta), apeluri repetate, apeluri efectuate eronat.", Fine = 1000, Jail = 10, CategoryId = 4 },
                             new Crime { Name = "Încălcarea condițiilor de eliberare condiționată", Description = "Incalcare conditii impuse in acordul de eliberare conditionata.", Fine = 1000, Jail = 8, CategoryId = 4 },
                             new Crime { Name = "Corupția", Description = "Savarsirea de infractiuni/abuzuri in legatura cu atributiile de serviciu sau de actiuni ilegale, de catre un functionar public.", Fine = 50000, Jail = 7, CategoryId = 4 },
                             new Crime { Name = "Ultraj judiciar - amenintari", Description = "Amenintari aduse unui functionar public in legatura cu atributiile de serviciu ( avand cunostinta de calitatea aceasta).", Fine = 1500, Jail = 9, CategoryId = 4 },
                             new Crime { Name = "Ultraj judiciar - loviri", Description = "Loviri/vatamari aduse unui functionar public in legatura cu atributiile de serviciu ( avand cunostinta de calitatea aceasta).", Fine = 2500, Jail = 6, CategoryId = 4 },
                              new Crime { Name = "Tulburarea ordinii si liniștii publice", Description = "Violențe împotriva persoanelor/bunurilor ori amenințări/ atingeri grave aduse demnității persoanelor într-un loc public. Perturbarea persoanelor din apropiere prin zgomote puternice/ tipete/ discurs verbal // incitare la violenta.", Fine = 1000, Jail = 3, CategoryId = 5 },
                             new Crime { Name = "Adunarea ilegală", Description = "Protest/demonstratie/intrunire ce nu se face in mod pasnic intr-o zona desemnata/ fara permisiune/autorizare corespunzatoare.", Fine = 300, Jail = 9, CategoryId = 5 },
                             new Crime { Name = "Incitare la revoltă", Description = "Acțiune ce intenționează să agite o mulțime sau un grup mare de persoane,într-o zonă publică/ privată pentru a promova acte de violență/ tulburări civile.Acțiuni într-o zonă publică ce incita violența, încurajeaza haosul.", Fine = 500, Jail = 3, CategoryId = 5 },
                             new Crime { Name = "Terorism", Description = "Amenințări sistematice/acțiuni împotriva binelui public pentru a provoca frică și intimidare la scară largă. Comiterea/ amenintarea cu un atac asupra unei importante unități publice/ private.", Fine = 50000, Jail = 4, CategoryId = 5 },
 new Crime { Name = "Tulburarea ordinii si liniștii publice", Description = "Violențe împotriva persoanelor/bunurilor ori amenințări/ atingeri grave aduse demnității persoanelor într-un loc public. Perturbarea persoanelor din apropiere prin zgomote puternice/ tipete/ discurs verbal // incitare la violenta.", Fine = 1000, Jail = 7, CategoryId = 6 },
 new Crime { Name = "Adunarea ilegală", Description = "Protest/demonstratie/intrunire ce nu se face in mod pasnic intr-o zona desemnata/ fara permisiune/autorizare corespunzatoare.", Fine = 300, Jail = 0, CategoryId = 6 },
 new Crime { Name = "Incitare la revoltă", Description = "Acțiune ce intenționează să agite o mulțime sau un grup mare de persoane,într-o zonă publică/ privată pentru a promova acte de violență/ tulburări civile.Acțiuni într-o zonă publică ce incita violența, încurajeaza haosul.", Fine = 500, Jail = 10, CategoryId = 6 },
 new Crime { Name = "Terorism", Description = "Amenințări sistematice/acțiuni împotriva binelui public pentru a provoca frică și intimidare la scară largă. Comiterea/ amenintarea cu un atac asupra unei importante unități publice/ private.", Fine = 50000, Jail = 6, CategoryId = 6 },
 new Crime { Name = "Posesia de substanțe controlate cu prafuri", Description = "Posesie de substante controlate, pana in si inclusiv 10 gr.", Fine = 500, Jail = 7, CategoryId = 7 },
 new Crime { Name = "Posesia de subst. controlate cu intenția de vânzare", Description = "Posesie de substante controlate, peste 10 dar sub 100 gr.", Fine = 2000, Jail = 2, CategoryId = 7 },
 new Crime { Name = "Posesia de droguri praf gravitate 1", Description = "Posesie de substante controlate, peste 100 dar sub 200 gr.", Fine = 4000, Jail = 4, CategoryId = 7 },
 new Crime { Name = "Posesia de droguri praf gravitate 2", Description = "Posesie de substante controlate, peste 200 dar sub 500 gr.", Fine = 8000, Jail = 8, CategoryId = 7 },
 new Crime { Name = "Posesia de droguri praf gravitate 3", Description = "Posesie de substante controlate, peste 500 gr.", Fine = 10000, Jail = 7, CategoryId = 7 },
 new Crime { Name = "Posesia de weed", Description = "Posesie de substante controlate sub 10 gr.", Fine = 500, Jail = 6, CategoryId = 7 },
 new Crime { Name = "Posesia de iarba gravitatea 1", Description = "Posesie de substante controlate, peste 10 dar sub 100 gr.", Fine = 1000, Jail = 0, CategoryId = 7 },
 new Crime { Name = "Posesia de iarba gravitatea 2", Description = "Posesie de substante controlate, peste 100 dar sub 200 gr.", Fine = 1500, Jail = 6, CategoryId = 7 },
 new Crime { Name = "Posesia de iarba gravitatea 3", Description = "Posesie de substante controlate, peste 200 dar sub 1 kg.", Fine = 3000, Jail = 6, CategoryId = 7 },
 new Crime { Name = "Condusul fără licență", Description = "Condusul unui vehicul fara detinerea permisului/ cu permis anulat.", Fine = 500, Jail = 9, CategoryId = 8 },
 new Crime { Name = "Condusul cu licența suspendată", Description = "Condusul unui vehicul avand permisul suspendat.", Fine = 1500, Jail = 5, CategoryId = 8 },
 new Crime { Name = "Fuga față de un ofițer", Description = "Fuga de politie indiferent ca este savarsita cu masina/nu.", Fine = 3000, Jail = 4, CategoryId = 8 },
 new Crime { Name = "Pilotarea fără licență", Description = "Pilotare elicopter/avion fara licenta.", Fine = 3000, Jail = 5, CategoryId = 8 },
 new Crime { Name = "Fugă de la locul accidentului", Description = "Fuga de la un accident, indiferent ca sunt implicate victime sau nu.", Fine = 500, Jail = 6, CategoryId = 8 },
 new Crime { Name = "Pilotarea unei aeronave într-un mod periculos", Description = "Efectuarea de manevre periculoase (ce pot aduce prejudicii orasului/ persoanelor).", Fine = 3500, Jail = 4, CategoryId = 8 },
 new Crime { Name = "Griparea/turarea motorului", Description = "Indiferent de locul savarsirii. Exceptie : evenimente, curse legale.", Fine = 200, Jail = 1, CategoryId = 8 },
 new Crime { Name = "Utilizarea Nos-ului pe drumurile publice", Description = "Nu este ilegal sa aveti instalatia de NOS, este ilegal sa fie folosit pe drumurile publice.", Fine = 2000, Jail = 0, CategoryId = 8 },
 new Crime { Name = "Circularea cu anvelope necorespunzatoare", Description = "Conducerea pe drumurile publice acoperite de zăpadă fără ca acesta să fie dotat cu anvelope de iarnă.", Fine = 500, Jail = 3, CategoryId = 8 },
 new Crime { Name = "Posesia unei arme albe", Description = "Lama, Cutit, Bata", Fine = 300, Jail = 10, CategoryId = 9 },
 new Crime { Name = "Posesie tazer fara aprobare", Description = "Tazer", Fine = 500, Jail = 6, CategoryId = 9 },
 new Crime { Name = "Posesia unei arme de foc mica", Description = "Pistol : vintage, SNS fara licenta port-arma", Fine = 1500, Jail = 4, CategoryId = 9 },
 new Crime { Name = "Posesia armelor de foc", Description = "Pistol : revolver, pistol mk2 ; Micro SMG;Tec", Fine = 2500, Jail = 2, CategoryId = 9 },
 new Crime { Name = "Posesia armelor automate de foc", Description = "AK 27, AK47 mk2, Shotgun dbd, Musketa, Tommy gun, Marksman Rifle, LMG", Fine = 3500, Jail = 1, CategoryId = 9 },
 new Crime { Name = "Fabricarea unei arme", Description = "Surprinderea unei persoane in timp/ imediat dupa ce fabrica o arma de orice calibru.", Fine = 2000, Jail = 7, CategoryId = 9 },
 new Crime { Name = "Traficul de armament", Description = "Vanzare de arme de orice calibru, in orice cantitate.Detinerea a 2/ mai multe arme = suspiciunea de trafic.", Fine = 4000, Jail = 9, CategoryId = 9 },
 new Crime { Name = "Posesia de explozibil", Description = "Molotov, C4", Fine = 2000, Jail = 4, CategoryId = 9 },

 new Crime { Name = "Folosire telefon/radio in timpul conducerii", Description = "Folosire in timpul deplasarii cu autovehiculul.", Fine = 250, Jail = 4, CategoryId = 10 },
 new Crime { Name = "Lipsa centurii de siguranta", Description = "Conducerea unui autovehicul fara a purta centura de siguranta.", Fine = 400, Jail = 5, CategoryId = 10 },
 new Crime { Name = "Circulatia pe un drum cu acces interzis", Description = "Alee pietonala, drum nesemnalat.", Fine = 200, Jail = 5, CategoryId = 10 },
 new Crime { Name = "Refuzul prezentarii actelor / verificare tehnica a autovehiculului", Description = "La control vamal / RAR / filtre ale politiei.", Fine = 1000, Jail = 4, CategoryId = 10 },
 new Crime { Name = "Parcarea/ oprirea în locuri interzise", Description = "Locuri ce nu sunt destinate parcarii, carosabil, zone restrictionate, autostrada.", Fine = 500, Jail = 5, CategoryId = 10 },
 new Crime { Name = "Nepăstrarea unei distanțe corespunzătoare", Description = "Apropierea fata de vehiculul din fata.", Fine = 500, Jail = 7, CategoryId = 10 },
 new Crime { Name = "Circularea fara asigurare", Description = "Asigurarea masinii.", Fine = 500, Jail = 1, CategoryId = 10 },
 new Crime { Name = "Nerespectarea unui semn de circulație", Description = "Nerespectare semafoare / indicatoare / indicatii politist rutiera/ vama.", Fine = 700, Jail = 9, CategoryId = 10 },
 new Crime { Name = "Viteza peste limita legala cu sub 50 km/h", Description = "71-119 km/h in oras/ 151-199 autostrada ", Fine = 1000, Jail = 6, CategoryId = 10 },
 new Crime { Name = "Viteza peste limita legala cu peste 50 km/h", Description = "120km/h + in oras / 200km/h + autostrada", Fine = 2000, Jail = 7, CategoryId = 10 },
 new Crime { Name = "Neacordarea de prioritate", Description = "Neacordare prioritate la intersectii de drumuri + pentru masini speciale.", Fine = 200, Jail = 6, CategoryId = 10 },
 new Crime { Name = "Schimbarea ilegală a directiei de mers", Description = "Schimbarea directiei cu încălcarea marcajului longitudinal continuu care separă sensurile de circulație.", Fine = 400, Jail = 10, CategoryId = 10 },
 new Crime { Name = "Condus imprudent", Description = "Condus haotic = viraje stanga/dreapta/ intoarceri fara a se asigura,nerespectarea unei distante sigure intre autovehicule, incapacitate de a mentine masina dreapta pe banda, etc. ", Fine = 800, Jail = 7, CategoryId = 10 },
 new Crime { Name = "Condus fiind intoxicat DWI", Description = "Condus sub influenta alcoolului / substante controlate. [0,8 alc> => inchisoare 30 min]", Fine = 200, Jail = 6, CategoryId = 10 },
 new Crime { Name = "Operarea unui vehicul neînregistrat", Description = "Condusul unui vehicul neinmatriculat, indiferent ca este/nu proprietarul masinii.", Fine = 500, Jail = 1, CategoryId = 10 },
 new Crime { Name = "Utilizarea bicicletei în condiții nesigure", Description = "Mersul pe mijlocul carosabilului + vezi condus imprudent.", Fine = 50000, Jail = 2, CategoryId = 10 },
 new Crime { Name = "Curse de stradă", Description = "Organizarea sau participarea (daca are cunostinta ca evenimentul e ilegal) la curse.", Fine = 1500, Jail = 2, CategoryId = 10 },
 new Crime { Name = "Traversarea în loc nepermis", Description = "Traversarea ca pieton prin locurile nemarcate de trecere.", Fine = 100, Jail = 3, CategoryId = 10 },
 new Crime { Name = "Geamuri fumurii", Description = "Detinerea de geamuri inchise la culoare pe masina condusa( indiferent ca e proprietar/nu).", Fine = 700, Jail = 2, CategoryId = 10 },
 new Crime { Name = "Neoane interzise", Description = "Interzisa montarea de lumini (neoane) pe autovehicule.", Fine = 500, Jail = 9, CategoryId = 10 },
 new Crime { Name = "Evaziune fiscală", Description = "Detinerea sau/si “spalarea” banilor “murdari”. Ca aceasta lege sa fie luata in considerare suspectul trebuie sa aiba asupra sa 2.000+", Fine = 1000, Jail = 2, CategoryId = 11 },
 new Crime { Name = "Încălcarea licenței", Description = "Detinerea unei afaceri fără licența de functionare. Realizarea de activitati ce necesita licenta fara a detine acest act. Organizarea de jocuri/curse ilegale.", Fine = 5000, Jail = 4, CategoryId = 11 },
 new Crime { Name = "Încălcarea regulilor practicii medicale", Description = "Prezentarea ca detinand licența de practicare a medicinii. Acordarea de servicii medicale cu neglijență criminala/intenția de a căuza vătămări.", Fine = 2000, Jail = 6, CategoryId = 11 },
 new Crime { Name = "Practicarea medicinei fără licenţă", Description = "Acordarea de servicii medicale fara a detine licenţă.", Fine = 3000, Jail = 9, CategoryId = 11 },
 new Crime { Name = "Interceptări ilegale", Description = "Interceptare sau supraveghere în mod ilegal fără un mandat/autorizație. Angajații guvernamentali pot fi înregistrați de către civili în permanență, când sunt în timpul serviciului. ( exceptie :avocati - discutiile confidentiale)", Fine = 3000, Jail = 5, CategoryId = 11 },
 new Crime { Name = "Actiuni conspirationale", Description = "Două sau mai multe persoane doresc să comită o acţiune ilegală asupra statului, ordinii publice sau asupra unei persoane.", Fine = 2000, Jail = 5, CategoryId = 11 },
 new Crime { Name = "Solicitarea unei crime", Description = "Solicitarea unei persoane să comită o infracţiune.", Fine = 2000, Jail = 0, CategoryId = 11 },
 new Crime { Name = "Munca la negru", Description = "Persoane ce sunt angajate si nu au carte de munca.", Fine = 4000, Jail = 8, CategoryId = 11 },
 new Crime { Name = "Frauda financiara", Description = "Se sanctioneaza proprietarul organizatiei ce angajeaza muncitori sau are muncitori ce au demisionat si nu a facut actele necesare la un avocat.", Fine = 1500, Jail = 9, CategoryId = 11 },
 new Crime { Name = "Neplata amenzii", Description = "Calcul zile-amenda, in cazul in care condamnatul nu are bani sa plateasca amenda.", Fine = 0, Jail = 5, CategoryId = 11 },
  new Crime { Name = "Tentativă", Description = "1. Incearcă să comită o crimă dar nu reușește din cauze exterioare vointei sale.2. Incepe comiterea dar se opreste din actiunile sale in timpul desfasurarii acesteia,fara a fi impiedicat de altcineva sau a auzi sirenele de politie. (proprie vointa)", Fine = 4000, Jail = 1, CategoryId = 12 },
 new Crime { Name = "Complicitate", Description = "- instigator (cu intenție, determină pe altul, la comiterea unei crime) – pedepsit ca autorul - complice direct-înlesnește, ușurează/ajută, comiterea unei crime – ¾ din ped autorului", Fine = 4000, Jail = 8, CategoryId = 12 },
 new Crime { Name = "Inducere in eroare a fortelor legale", Description = "Fals in declaratii savarsit cu intentia de a da o pista falsa/ a induce in eroare o ancheta a politiei a porni o ancheta asupra unei persoane fara motiv.", Fine = 4000, Jail = 3, CategoryId = 12 },
 new Crime { Name = "Tentativa/ Distrugerea de probe/ dovezi", Description = "Incercarea de distrugere/ distrugere de probe/dovezi, indiferent de motiv.", Fine = 4000, Jail = 0, CategoryId = 12 }


                                                                                                    );
                    context.SaveChanges();

                }
                if (context.Roles.Any())
                {
                    return;   // baza de date contine deja roluri
                }

                // CREAREA ROLURILOR IN BD
                // daca nu contine roluri, acestea se vor crea
                context.Roles.AddRange(
                    new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                    new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "User", NormalizedName = "User".ToUpper() }

                );


                // o noua instanta pe care o vom utiliza pentru crearea parolelor utilizatorilor
                // parolele sunt de tip hash
                var hasher = new PasswordHasher<ApplicationUser>();

                // CREAREA USERILOR IN BD
                // Se creeaza cate un user pentru fiecare rol
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb0", // primary key
                        UserName = "admin@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@TEST.COM",
                        FirstName = "Admin",
                        LastName = "Test",
                        Email = "admin@test.com",
                        NormalizedUserName = "ADMIN@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1!")
                    },
                  /*  new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb1", // primary key
                        UserName = "mod@test.com",
                        EmailConfirmed = true,
                        FirstName = "Moderator",
                        LastName = "Test",
                        NormalizedEmail = "MOD@TEST.COM",
                        Email = "mod@test.com",
                        NormalizedUserName = "MOD@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Moderator1!")
                    },*/
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb2", // primary key
                        UserName = "user@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "USER@TEST.COM",
                        FirstName = "User",
                        LastName = "Test",
                        Email = "user@test.com",
                        NormalizedUserName = "USER@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "User1!")
                    }
                ); ;
                context.UserRoles.AddRange(
                   new IdentityUserRole<string>
                   {
                       // Admin
                       RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                       UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
                   },
                   new IdentityUserRole<string>
                   {
                       /// User
                       RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                       UserId = "8e445865-a24d-4543-a6c6-9443d048cdb2"
                   }
                  
               );
                context.SaveChanges();
            }

        }

    }
}
