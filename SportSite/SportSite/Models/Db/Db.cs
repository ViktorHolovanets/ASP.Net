using Microsoft.EntityFrameworkCore;

namespace SportSite.Models.Db
{
    public class Db:DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TimeOfWork> TimeOfWorks { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TypeSport> TypeSports { get; set; }
        public virtual DbSet<CreateCodeAccounts> Code { get; set; }
        public Db(DbContextOptions<Db> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public User GetUser(string Id)
        {
            return Users.FirstOrDefault(x => x.Id.ToString() == Id);
        }
        public void AddTypeSport()
        {
            TypeSports.Add(new TypeSport()
            {
                Name = "CrossFit",
                Details = @"What is CrossFit?
                    A form of high intensity interval training,
                    CrossFit is a strength and conditioning workout that is made up of functional movement performed at a high intensity level.

                    These movements are actions that you perform in your day - to - day life, like squatting, pulling, pushing etc.Many workouts feature variations of squats, push - ups,
                    and weight lifting that last for predetermined amounts of time to help build muscles.This varies from a traditional workout that may tell you how many reps to do over any period of time.

                    CrossFit Journal notes that the workouts are so effective because of their emphasis on the elements of load, distance and speed, which help participants develop high levels of power.The workout may utilize different equipment to accomplish this, including kettle bells, rowers and bikes, medicine balls, speed ropes, rings and plyo boxes.

                    CrossFit is similar to Orange Theory in that there is a standard `workout of the day`(WOD) that all members complete on the same day. The daily workout can be found on their website(which is always free), along with a guide to all the specialized lingo that is used.There is also a substitutions section on their FAQ page that suggests places to find level appropriate workouts. “CrossFit is universally scalable and modifiable for all fitness levels, so it can be tailored to meet your goals and current fitness level,” says Tracey Magee, owner and head coach of CrossFit Clan Performance Center.",
                Image="/Images/1.jpg"
            });
            TypeSports.Add(new TypeSport()
            {
                Name = "Yoga",
                Details = @"What does Yoga mean?
                    Yoga is a physical, mental and spiritual practice that originated in ancient India. First codified by the sage Patanjali in his Yoga Sutras around 400 C.E, the practice was in fact handed down from teacher to student long before this text arose. Traditionally, this was a one-to-one transmission, but since yoga became popular in the West in the 20th century, group classes have become the norm.

                    The word yoga is derived from the Sanskrit root yuj, meaning “to yoke,” or “to unite”. The practice aims to create union between body, mind and spirit, as well as between the individual self and universal consciousness. Such a union tends to neutralize ego-driven thoughts and behaviours, creating a sense of spiritual awakening.

                    Yoga has been practiced for thousands of years, and whilst many different interpretations and styles have been developed, most tend to agree that the ultimate goal of yoga is to achieve liberation from suffering. Although each school or tradition of yoga has its own emphasis and practices, most focus on bringing together body, mind and breath as a means of altering energy or shifting consciousness.",
                Image = "/Images/yoga.jpg"
            });
            TypeSports.Add(new TypeSport()
            {
                Name = "GYM",
                Details = @"The gym offers a unique opportunity to take care of your body and improve your health. In the arsenal there are the most popular and effective simulators that will help you get enviable forms.

                    The hall is designed for general physical and strength training of professional athletes and just those who want to pump up and increase endurance. For visitors are available:
                    • cardio equipment (tracks, steppers, exercise bikes);
                    • weight block simulators;
                    • simulators for individual muscle groups (abdomen, hips, back, etc.);
                    • power simulators (dumbbells, benches, etc.).

                    In our hall you can:
                    • reduce weight;
                    • gain muscle mass;
                    • adjust the figure;
                    • Eliminate problem areas and much more.

                    We have created all conditions for comfortable training. In addition to modern simulators, the room is provided with an air conditioning system. To improve conditions, eliminate discomfort and expectations, there is a limit on the number of students. During classes, athletes will be able to enjoy not only a useful pastime, but also the pleasant sound of their favorite tracks. We always listen to the wishes of our visitors and select the most suitable music for the gym.

                    You can work out in the gym both independently and under the strict guidance of our highly qualified trainers. Many years of experience allows them to select the best option for exercises, depending on the goals that the client wants to achieve. Among the employees are prize-winners and winners of domestic and international bodybuilding competitions. Professionals in their field will help you adjust your daily routine and nutrition to achieve the desired result faster.",
                Image = "/Images/gym.jpg"
            });
            TypeSports.Add(new TypeSport()
            {
                Name = "Solariy",
                Details = @"Lorem ipsum, dolor sit amet consectetur adipisicing elit. Obcaecati debitis consequuntur, repellat nemo ab accusantium ullam ea perspiciatis! Molestiae cupiditate consequuntur vero ad dicta eligendi, autem aperiam? Voluptates, nesciunt sequi.",
                Image = "/Images/solariy.jpg"
            });
            TypeSports.Add(new TypeSport()
            {
                Name = "Phytobar",
                Details = @"Lorem ipsum, dolor sit amet consectetur adipisicing elit. Obcaecati debitis consequuntur, repellat nemo ab accusantium ullam ea perspiciatis! Molestiae cupiditate consequuntur vero ad dicta eligendi, autem aperiam? Voluptates, nesciunt sequi.",
                Image = "/Images/phytobar.jpg"
            });
            TypeSports.Add(new TypeSport()
            {
                Name = "Massage",
                Details = @"Lorem ipsum, dolor sit amet consectetur adipisicing elit. Obcaecati debitis consequuntur, repellat nemo ab accusantium ullam ea perspiciatis! Molestiae cupiditate consequuntur vero ad dicta eligendi, autem aperiam? Voluptates, nesciunt sequi.",
                Image = "/Images/massage.jpg"
            });
            Accounts.Add(new Account()
            {
                Client = new User()
                {
                    Age = 1,
                    Email = "asd@asd.com",
                    Gender = Gender.Man,
                    Name = "test",
                    Surname = "test",
                    Tel = "+3802222"
                },
                Login="admin",
                Password="admin",
                Role=Role.manager
            });
            this.SaveChanges();
        }
    }
}
