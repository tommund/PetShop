using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data
{
    public class PetsContext : DbContext
    {
        public PetsContext(DbContextOptions<PetsContext> options) : base(options)
        {

        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //initiliaze categories
            modelBuilder.Entity<Category>().HasData(
              new { Id = 1, Name = "Mammals" },
              new { Id = 2, Name = "Reptiles" },
              new { Id = 3, Name = "Amphibians" },
              new { Id = 4, Name = "Aves" }
          ); ;


            modelBuilder.Entity<Animal>().HasData(
                new { Id = 1, Name = "Aardvark", Age = 10.0, PictureName = "/Images/aardvark.jpg", Description = "Aardvarks are small pig-like mammals that are found inhabiting a wide range of different habitats throughout Africa, south of the Sahara. They are mostly solitary and spend their days sleeping in underground burrows to protect them from the heat of the African sun, emerging in the cooler evening to search for food. Their name originates from the Afrikaans language in South Africa and means Earth Pig, due to their long snout and pig-like body.", CategoryId = 1 },
                new { Id = 2, Name = "Afghan Hound", Age = 5.0, PictureName = "/Images/afgan hound.jpg", Description = "The Afghan Hound is thought to be one of the oldest of all domestic Dog breeds, with the first records of the Afghan Hound dating back to 4,000 BC. The fast and agile nature of this Dog meant that they made excellent hunters of small game in their native Afghanistan, most commonly hunting Deer, Goats, Gazelle and Wild Boar along with seeing off larger predators such as Wolves and Snow Leopards.", CategoryId = 1 },
                 new { Id = 3, Name = "Akita", Age = 3.5, PictureName = "/Images/akita_dog.jpg", Description = "Due to the fact that the Akita has been historically bred as both a hunting and a fighting Dog, they are naturally aggressive and very dominant animals. Akitas have changed very little since they were first produced, with household individuals still having strong hunting instincts today. They are therefore, not for the inexperienced owner as they require firm and consistent training with lots of positive reinforcement. The Akita is also known to respond badly to harsh treatment. They are incredibly intelligent and loyal Dogs though, and are loving, devoted and gentle towards their master and family. The Akita is also known to be a good guard Dog as it is very suspicious of any person or animal that it doesn’t know.", CategoryId = 1 },
                  new { Id = 4, Name = "Baboons", Age = 7.0, PictureName = "/Images/baboon.jpg", Description = "Baboons are incredibly sociable animals that live in large troops that can be very varied in size and can contain a few hundred members. Baboon troops consist of both males and females with their young and form very close bonds by feeding, sleeping and grooming together. During the day they break into smaller bands of 4 or 5 females and young, that is led by a dominant male who attempts to keep other males away. The Hamadryas Baboon however, lives in much smaller groups of around 12 females and a single alpha male. Baboons live together for protection and are constantly on the look-out for dangerous predators, particularly when they are out in the open. If a threat is spotted, they make loud barks and while the males run to attack, the females and young disappear up into the safety of the trees. Baboons communicate between one another in a variety of different ways including vocals calls, facial expressions and even signal with their tails.", CategoryId = 1 },
                  new { Id = 5, Name = "chinchilla", Age = 1.0, PictureName = "/Images/chinchilla.jpg", Description = "The body of an average chinchilla grows to about 10 inches long, but they can range from 8 inches to 12 inches and their tail will typically be about 5 inches in length. A chinchilla that is fully grown typically weighs between 1 and 3 pounds. A healthy chinchilla with a large build should not weigh more than 3.3 pounds. Female chinchillas grow larger than male chinchillas.", CategoryId = 1 },
                  new { Id = 6, Name = "Fox", Age = 4.0, PictureName = "/Images/fox.jpg", Description = "Wild foxes tend live for around 6-7 years, but some foxes have been known to be older than 13 in captivity. The wild fox hunts for the mouse and other small mammals and birds, but foxes appear to enjoy all species of insect.A fox is generally smaller than other members of the dog family like wolves, jackals and domestic dogs.Foxes can be a pest in the cities as foxes are often seen tearing into rubbish.", CategoryId = 1 },




            new { Id = 7, Name = "Iguana", Age = 1.3, PictureName = "/Images/iguana2.jpg", Description = "Iguanas are native to the jungles of central and south America, and the Caribbean.The iguana is a large docile species of lizard, meaning that iguanas are often a popular choice when keeping exotic pets. Iguanas have excellent sight allowing the iguana to detect movement from incredibly long distances.The iguana can use this skill to seek out prey and be aware of approaching predators often before the predator has even noticed the iguana. It is said that the iguana uses visual signals to communicate with other iguanas.The iguanas do this through a series of rapid eye movements that other iguanas are able to pick up on easily due to the excellent sight of the iguana. Green Iguanas are forest dwelling lizards that live high in the tree canopy of the South American rainforest. Young iguanas get to grips with tree top living by staying in areas lower in the canopies while older mature adult iguanas reside higher up in the tree tops.This tree dwelling habit allows the iguana to bask in the sun, with little need to go down to the forest floor below. The only real exception to this is when the female iguanas must come down from their sky high home in order to dig burrows in which the female iguanas lay their eggs.", CategoryId = 2 },
            new { Id = 8, Name = "Lizard", Age = 0.1, PictureName = "/Images/lizard4-600x400.jpg", Description = "Lizard is a collective name for the different species of lizard that are found in the warmer climates around the world. The lizard is a reptile with scaly skin, and some species of lizard can shed their tails when they are in danger, but not all species of lizard are capable of doing this.There are around 5,000 different species of lizard ranging from small lizards that are just a few centimeters in size,to much larger and more predatory lizards that measure a few meters from the head of the lizard to the tip of their tail. Most species of lizard are either good climbers,  or failing that good at sprinting which enables all the different species of lizard to escape danger in a flash.Some species of lizard are said to be so good at anchoring themselves into solid material that it has been known that criminals breaking into houses are able to use the lizard almost like a ladder,and therefore are able to climb up the lizard into the house.", CategoryId = 2 },
            new { Id = 9, Name = "tortoise", Age = 50.0, PictureName = "/Images/tortoise4-600x400.jpg", Description = " The tortoises is a land-dwelling reptile closely related to the tortoise’s marine cousin the sea turtle. The tortoise is found in many countries around the world but particularly in the southern hemisphere where the weather is warmer for most of the year. Tortoises have a hard outer shell to protect them from predators but the skin on the legs, head and belly of the tortoise is quite soft so the tortoise is able to retract its limbs into its shell to protect itself.The tortoise’s shell can range in size from a few centimetres to a couple of metres, depending on the species of tortoise. Most species of tortoise have a herbivorous diet eating grasses, weeds, flowers, leafy greens and fruits.Tortoises generally have a lifespan similar to the lifespan of humans although some species of tortoise, like the giant tortoise, have known to be over 150 years old.", CategoryId = 2 },
            new { Id = 10, Name = "Gecko", Age = 0.2, PictureName = "/Images/gecko8-326x400.jpg", Description = "The gecko is a small to medium species of lizard that is found in the more temperate and tropical regions of the world. Geckos are more commonly found around the Equator and in the Southern Hemisphere although a few species of gecko are found north of the Equator in warmer regions.", CategoryId = 2 },
            new { Id = 11, Name = "Sea turtle", Age = 20.00, PictureName = "/Images/sea_turtle10-600x400.jpg", Description = "Sea turtles are found in all of the major oceans and smaller seas with the exception of the Arctic Circle as it is generally too cold for sea turtles as they tend to prefer more temperate waters. The bigger species of sea turtle are found more in the Southern Hemisphere in the tropical, warmer waters.", CategoryId = 2 },

            new { Id = 12, Name = "Pool frog", Age = 0.3, PictureName = "/Images/pool_frog-600x400.jpg", Description = "The pool frog is a medium sized frog that is generally brown or brownish-green in colour with a splattering of dark spots across its skin. Pool frogs are also easily identified by their sharply pointed heads and by the two, lightly coloured stripes that run down either side of the pool frog’s back.", CategoryId = 3 },
            new { Id = 13, Name = "Salamander", Age = 0.4, PictureName = "/Images/salamander-600x400.jpg", Description = "Next time you see a salamander, take a moment to study it. These creatures look like a cross between a lizard and a frog. Its flat head looks kind of like a frog’s head while its long, smooth body, four short legs and tail look like a lizard’s. Though there are similarities between lizards and salamanders, a lizard is a reptile and a salamander is an amphibian.", CategoryId = 3 },
            new { Id = 14, Name = "Axolotl", Age = 0.5, PictureName = "/Images/axolotl3-445x400.jpg", Description = "Axolotls are often referred to as “Mexican walking fish,” but they are actually amphibians that prefer to live their entire lives underwater. These remarkable creatures can regenerate almost every part of their bodies if necessary, including their spines, internal organs and even some parts of their brains. They have a very unique appearance and are extremely popular as exotic pets", CategoryId = 3 },
            new { Id = 15, Name = "Frog", Age = 0.4, PictureName = "/Images/frog4-600x400.jpg", Description = "Frogs are well known for their coiled, sticky tongue which they project out of their mouths to catch insects. Frogs are also well known for being able to breathe through their skin as well as their lungs.", CategoryId = 3 },
            new { Id = 16, Name = "Common toad", Age = 0.5, PictureName = "/Images/common_toad7-600x400.jpg", Description = "On average, common toads are about 10 to 18 centimeters (4 to 7 inches) long. How much does a common toad weigh? The species usually weighs between 20 and 80 grams (0.7 and 2.8 ounces). In other words, the biggest European toads only weigh half as much as a baseball! Southern toads are typically larger than their northern counterparts, and females are usually bigger than males.", CategoryId = 3 },

             new { Id = 17, Name = "Parrot", Age = 1.0, PictureName = "/Images/parrot2-273x400.jpg", Description = "The parrot is a medium sized group of birds, with the parrot being best known for it’s extremely brightly coloured feathers, and the ability of some parrot species to talk, as these species of parrots are able to mimic sounds made by other animals such as humans.", CategoryId = 4 },
            new { Id = 18, Name = "robin", Age = 0.4, PictureName = "/Images/robin5-600x400.jpg", Description = "The robin is a small bird, originally found in only Europe and Asia. The robin today can be found across the world in parts of Africa, North America and New Zealand but all of these robin species are believed to be subspecies of the European robin.", CategoryId = 4 },
            new { Id = 19, Name = "Duck", Age = 2.0, PictureName = "/Images/duck7-600x400.jpg", Description = "Ducks are medium sized aquatic birds related to other aquatic birds like swans and geese. Ducks differ from swans and geese in their tendency to dive into the water in order catch their food.", CategoryId = 4 },
            new { Id = 20, Name = "Puffin", Age = 1.2, PictureName = "/Images/puffin-600x400.jpg", Description = "Puffins are small sized birds that have thick black and white plumage that helps to keep them warm in the cold conditions of the northernmost, Northern Hemisphere. They have black necks, backs and wings with white underparts and whitish feathers on the sides of the face. Their feet and legs are a dull yellow colour during the colder winter months, changing to a bright orange during the breeding season.", CategoryId = 4 },
            new { Id = 21, Name = "Quail", Age = 0.5, PictureName = "/Images/quail8-600x400.jpg", Description = "These are small birds that are generally bigger than robins but smaller than crows, although you’ll find a great difference among the species. Some are as small as four inches tall and can range up to 11 or 12 inches in height. They have small heads and short, broad wings along with a long and square tail. Both males and females have a topknot of feathers that project forward, with males having a longer and bigger plume, which are dark and comprised of several feathers.", CategoryId = 4 }

            ); ;
            modelBuilder.Entity<Comment>().HasData(
               new { Id = 1, AnimalId = 1, CommentText = "i really like this animal" },
               new { Id = 2, AnimalId = 1, CommentText = "wow" },
                new { Id = 3, AnimalId = 2, CommentText = "amazing dog" }
           );

        }


    }
}
