using MovieRatingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRatingApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(MovieRatingApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.MediaTypes.Any())
            {
                return;   // DB has been seeded
            }

            var types = new MediaType[]
            {
                new MediaType {
                    Key = "MOVIE",
                    Name = "Movie"
                },
                new MediaType {
                    Key = "TV_SHOW",
                    Name = "Tv Show"
                }
            };

            foreach (var type in types)
            {
                context.MediaTypes.Add(type);
            }

            context.SaveChanges();

            if (context.Actors.Any())
            {
                return;   // DB has been seeded
            }

            var actors = new Actor[]
            {
                new Actor {
                    Name = "Chris",
                    Surname = "Hemsworth"
                },
                new Actor {
                    Name = "Tom",
                    Surname = "Holland"
                },
                new Actor {
                    Name = "Anthony",
                    Surname = "Hopkins"
                },
                new Actor {
                    Name = "Robert",
                    Surname = "Downey Jr."
                },
                new Actor {
                    Name = "Mark",
                    Surname = "Ruffalo"
                },
                new Actor {
                    Name = "Matt",
                    Surname = "LeBlanc"
                },
                new Actor {
                    Name = "Matthew",
                    Surname = "Perry"
                },
                new Actor {
                    Name = "Jennifer",
                    Surname = "Aniston"
                },
                new Actor {
                    Name = "Brad",
                    Surname = "Pitt"
                },
                new Actor {
                    Name = "Antonio",
                    Surname = "Banderas"
                }
            };

            foreach (var actor in actors)
            {
                context.Actors.Add(actor);
            }

            context.SaveChanges();

            if (context.Medias.Any())
            {
                return;   // DB has been seeded
            }

            var movieType = context.MediaTypes.FirstOrDefault(x => x.Key == "MOVIE").Id;
            var tvShow = context.MediaTypes.FirstOrDefault(x => x.Key == "TV_SHOW").Id;

            var movies = new Media[]
            {
                new Media {
                    Title = "Spider-Man: Homecoming",
                    Description = "Following the Battle of New York in 2012,[N 1] Adrian Toomes and his salvage company are contracted to clean up the city," +
                    "but their operation is taken over by the Department of Damage Control (DODC), a partnership between Tony Stark and the U.S. government." +
                    "Enraged at being driven out of business, Toomes persuades his employees to keep the Chitauri technology they have already scavenged and use " +
                    "it to create and sell advanced weapons, including a flying Vulture suit Toomes uses to steal Chitauri power cells. Eight years later,[N 2] " +
                    "Peter Parker is drafted into the Avengers by Stark to help with an internal dispute in Berlin,[N 3] but resumes his studies at the Midtown School of Science and Technology when Stark tells him he is not yet ready to become a full Avenger... ",
                    ReleaseDate = DateTime.Parse("2017-06-28"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Captain America: Civil War",
                    Description = "In 1991, the brainwashed super-soldier James \"Bucky\" Barnes is dispatched from a Hydra base in Siberia to intercept an" +
                    "automobile carrying a case of super-soldier serum. In the present day, approximately one year after Ultron is defeated by the Avengers in " +
                    "the nation of Sokovia,[N 1] Steve Rogers, Natasha Romanoff, Sam Wilson, and Wanda Maximoff stop Brock Rumlow from stealing a biological weapon from a lab in Lagos. " +
                    "Rumlow blows himself up, attempting to kill Rogers. Maximoff telekinetically diverts the explosion, accidentally destroying a nearby building and killing several Wakandan humanitarian workers in the process...",
                    ReleaseDate = DateTime.Parse("2016-4-12"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Avengers: Infinity War",
                    Description = "Having acquired the Power Stone–one of the six Infinity Stones–from the planet Xandar, Thanos and his lieutenants: Ebony Maw, Cull Obsidian, Proxima Midnight, and Corvus Glaive, intercept the spaceship " +
                    "carrying the survivors of Asgard's destruction.[N 1] After subduing Thor, Thanos extracts the Space Stone from the Tesseract, overpowers the Hulk, and kills Loki. " +
                    "Thanos also kills Heimdall after he sends Hulk to Earth using the Bifröst. Thanos and his lieutenants leave, destroying the ship. Hulk crash-lands in the Sanctum Sanctorum in New York City, reverting to the form of Bruce Banner. " +
                    "He warns Stephen Strange and Wong about Thanos' plan to destroy half of all life in the universe, and they recruit Tony Stark. Maw and Obsidian arrive to retrieve the Time Stone from Strange, " +
                    "drawing Peter Parker's attention. Maw is unable to take the Time Stone due to an enchantment and captures Strange. Stark and Parker sneak aboard Maw's spaceship while Wong stays behind to guard the Sanctum ...",
                    ReleaseDate = DateTime.Parse("2018-04-23"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "The Curious Case of Benjamin Button",
                    Description = "In August 2005, elderly Daisy Fuller is on her deathbed in a New Orleans hospital as Hurricane Katrina approaches. She tells her daughter, Caroline, about a train station built in 1918 and a blind clockmaker, " +
                    "Mr. Gateau, hired to make a clock for it. When it was unveiled at the station, the public was surprised to see the clock running backwards. Mr. Gateau says he made it that way as a memorial, so that the children they lost in " +
                    "World War I, including his own son, could come home again and live full lives. Mr. Gateau was never seen again. Daisy then asks Caroline to read aloud from the diary of Benjamin Button. ...",
                    ReleaseDate = DateTime.Parse("2008-12-25"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Interview with the Vampire",
                    Description = "In modern-day San Francisco, reporter Daniel Molloy interviews Louis de Pointe du Lac, who claims to be a vampire. Louis describes his human life as a wealthy plantation owner in 1791 Spanish Louisiana. Despondent " +
                    "following the death of his wife and unborn child, he drunkenly wanders the waterfront of New Orleans one night and is attacked by the vampire Lestat de Lioncourt. Lestat senses Louis's dissatisfaction with life and offers to turn him " +
                    "into a vampire. Louis accepts, but quickly comes to regret it. While Lestat revels in the hunt and killing of humans, Louis resists his instinct to kill, instead drinking animal blood to sustain himself. Disgusted by Lestat's pleasure in " +
                    "killing, Louis comes to suffer tremendously as a vampire. ...",
                    ReleaseDate = DateTime.Parse("1994-11-11"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Meet Joe Black",
                    Description = "Media mogul Bill Parrish is contemplating a merger with another media giant. Also his eldest, Alison, is planning an elaborate 65th birthday party for him. His younger daughter Susan, a resident in internal medicine, has a relationship with Drew, one of Bill's board members." +
                    "Considering marriage, as Bill sees Susan is not deeply in love, he suggests she wait to be swept off of her feet, suggesting \"lightning could strike!\". When the company helicopter lands, he hears a mysterious voice, which he tries to ignore. Arriving in his office, Bill has sharp pains in his chest and hears the voice again, saying, \"Yes.\"" +
                    "While studying in a coffee shop, Susan meets a vibrant young man who also says \"lightning may strike\" a relationship between them. Stunned, she departs without getting his name. Unbeknownst to her, directly afterward, he is struck by multiple cars",
                    ReleaseDate = DateTime.Parse("1998-11-13"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Hannibal ",
                    Description = "A decade after tracking down serial killer Jame Gumb,[a] FBI Special Agent Clarice Starling is blamed for a botched drug raid which results in the deaths of five people. Starling is contacted by Mason Verger, the only surviving victim of the cannibalistic serial killer Hannibal Lecter, who has been missing since escaping custody " +
                    "during the Gumb investigation. A wealthy child molester, Verger was paralyzed and disfigured by Lecter during a therapy session. He has been pursuing an elaborate scheme to capture, torture, and kill Lecter ever since. Using his wealth and political influence, Verger has Starling reassigned to Lecter's case, hoping her involvement will draw Lecter out. ...",
                    ReleaseDate = DateTime.Parse("2001-02-09"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "The Mask of Zorro",
                    Description = "In 1821, Don Diego de la Vega, a Spanish-born California nobleman, fights against the Spanish in the Mexican War of Independence as Zorro, a mysterious masked swordsman who defends the Mexican peasants and commoners of Las Californias. Don Rafael Montero, the corrupt governor of the region, sets a trap for Zorro at a public execution of three " +
                    "innocent peasants. Zorro stops the execution, and Montero's soldiers are thwarted by two young brothers, Alejandro and Joaquin Murietta. Zorro fights the remaining Spanish soldiers and thanks the Murrieta brothers by giving them a silver medallion. Don Montero suspects de la Vega of being Zorro and attempts to arrest him at his home. A sword fight begins, a fire breaks out, " +
                    "and de la Vega's wife Esperanza, whom Montero was in love with, is shot and killed during the ensuing scuffle. While Diego's home burns, Montero takes his infant daughter, Elena, as his own before sending de la Vega to prison and returning to Spain.  ...",
                    ReleaseDate = DateTime.Parse("1998-07-17"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Thor",
                    Description = "In 965 AD, Odin, king of Asgard, wages war against the Frost Giants of Jotunheim and their leader Laufey, to prevent them from conquering the Nine Realms, starting with Earth. The Asgardian warriors defeat the Frost Giants in Tønsberg, Norway, and seize the source of their power, the Casket of Ancient Winters." +
                    "In the present,[N 2] Odin's son Thor prepares to ascend to the throne of Asgard, but is interrupted when Frost Giants, secretly allowed in by his brother Loki, attempt to retrieve the Casket. Against Odin's order, Thor travels to Jotunheim to confront Laufey, accompanied by Loki, childhood friend Sif an ...",
                    ReleaseDate = DateTime.Parse("2011-04-17"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Thor: The Dark World",
                    Description = "Eons ago, Bor, father of Odin, clashes with the Dark Elf Malekith, who seeks to unleash a weapon known as the Aether on the nine realms. After conquering Malekith's forces, including enhanced warriors called the Kursed, on their home world of Svartalfheim, Bor safeguards the Aether within a stone column. Unknown " +
                    "to Bor, Malekith and a handful of Dark Elves escape into suspended animation. ...",
                    ReleaseDate = DateTime.Parse("2013-10-22"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Thor: Ragnarok",
                    Description = "Two years after the battle of Sokovia,[N 1] Thor is imprisoned by the fire demon Surtur, who reveals that Thor's father Odin is no longer on Asgard. He explains that the realm will soon be destroyed during the prophesied Ragnarök, once Surtur unites his crown with the Eternal Flame that burns in Odin's vault. " +
                    "Thor frees himself, defeats Surtur and takes his crown, believing he has prevented Ragnarök. ...",
                    ReleaseDate = DateTime.Parse("2017-10-10"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "The Avengers",
                    Description = "The Asgardian Loki encounters the Other, the leader of an extraterrestrial race known as the Chitauri. In exchange for retrieving the Tesseract,[N 2] a powerful energy source of unknown potential, the Other promises Loki an army with which he can subjugate Earth. Nick Fury, director of the espionage agency S.H.I.E.L.D., " +
                    "arrives at a remote research facility, where physicist Dr. Erik Selvig is leading a team experimenting on the Tesseract. The Tesseract suddenly activates and ...",
                    ReleaseDate = DateTime.Parse("2012-04-11"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Avengers: Endgame",
                    Description = "In 2018, twenty-three days after Thanos killed half of all life in the universe,[N 1] Carol Danvers rescues Tony Stark and Nebula from deep space and they reunite with the remaining Avengers—Bruce Banner, Steve Rogers, Thor, Natasha Romanoff, and James Rhodes—and Rocket on Earth. Locating Thanos on an uninhabited planet, " +
                    "they plan to use the Infinity Stones to reverse his actions, but discover Thanos has already destroyed them to prevent further use. Enraged, Thor decapitates Thanos ...",
                    ReleaseDate = DateTime.Parse("2019-04-26"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Shang-Chi and the Legend of the Ten Rings",
                    Description = "Thousands of years ago, Xu Wenwu discovers the mystical ten rings which grant immortality and godly powers. He establishes the Ten Rings organization, conquering kingdoms and toppling governments throughout history. In 1996, Wenwu searches for Ta Lo, a village said to harbor mythical beasts. He travels through a magical " +
                    "forest to the village entrance but is stopped by guardian Ying Li. The two fall in love, and Wenwu abandons the Ten Rings. When the villagers reject Wenwu, Li chooses to leave with him and they have two children, Shang-Chi and Xialing. When Shang-Chi is 7, Li is murdered by Wenwu's enemies, the Iron Gang. Wenwu massacres the Iron Gang...",
                    ReleaseDate = DateTime.Parse("2021-08-16"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Dark Waters",
                    Description = "Robert Bilott is a corporate defense lawyer from Cincinnati, Ohio working for law firm Taft Stettinius & Hollister. Farmer Wilbur Tennant, who knows Robert's grandmother, asks Robert to investigate a number of unexplained animal deaths in Parkersburg, West Virginia. Tennant connects the deaths to the chemical " +
                    "manufacturing corporation DuPont, and gives Robert a large case of videotapes. ...",
                    ReleaseDate = DateTime.Parse("2019-12-19"),
                    TypeId = movieType,
                },
                new Media {
                    Title = "Friends",
                    Description = "Rachel Green, a sheltered but friendly woman, flees her wedding day and wealthy yet unfulfilling life and finds childhood friend Monica Geller, a tightly wound but caring chef. Rachel becomes a waitress at West Village coffee house Central Perk after she moves into Monica's apartment above Central Perk and joins " +
                    "Monica's group of single friends in their mid-20s: previous roommate Phoebe Buffay, an eccentric masseuse and musician; neighbor Joey Tribbiani, a dim-witted yet loyal struggling actor and womanizer; Joey's roommate Chandler Bing, a sarcastic, self-deprecating data processor; and Monica's older brother and Chandler's college roommate " +
                    "Ross Geller, a sweet-natured but insecure paleontologist. ...",
                    ReleaseDate = DateTime.Parse("1994-09-22"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "How I Met Your Mother",
                    Description = "The series follows the adventures of Ted Mosby (played by Josh Radnor) and his love life as a single man. His stories are narrated by Bob Saget as Ted Mosby twenty-five years later as he tells them to his adolescent children. " +
                    "The story goes into a flashback and starts in 2005 with the 27-year-old Ted Mosby living in New York City and working as an architect. ...",
                    ReleaseDate = DateTime.Parse("2005-09-19"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Frasier",
                    Description = "Harvard educated psychiatrist Frasier Crane (Grammer) returns to his hometown of Seattle, Washington, following the end of his marriage and life in Boston (as seen in Cheers). His plans for a new life as a single man are challenged, however, when he is obliged to take in his father, Martin (Mahoney), a retired Seattle " +
                    "Police Department detective, who has mobility problems after being shot in the line of duty during a robbery....",
                    ReleaseDate = DateTime.Parse("1993-09-16"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "The Walking Dead",
                    Description = "The Walking Dead takes place years after the onset of a worldwide zombie apocalypse. The zombies, referred to as \"walkers\", shamble towards living humans and other creatures to eat them; they are attracted to noise, such as gunshots, and to different scents, e.g. humans, especially fresh blood. Although it initially seems " +
                    "that only humans that are bitten or scratched by walkers can turn into other walkers, it is revealed early in the series that all living humans carry the pathogen responsible for the mutation. The mutation is activated after the death of the pathogen's host, and the only way to permanently kill a walker is to damage its brain or destroy" +
                    " the body entirely, such as by cremating it....",
                    ReleaseDate = DateTime.Parse("2010-10-31"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Game of Thrones",
                    Description = "Game of Thrones is roughly based on the storylines of the A Song of Ice and Fire book series by George R. R. Martin, set in the fictional Seven Kingdoms of Westeros and the continent of Essos. " +
                    "The series follows several simultaneous plot lines. The first story arc follows a war of succession among competing claimants for control of the Iron Throne of the Seven Kingdoms, with other noble families " +
                    "fighting for independence from the throne. The second concerns the exiled scion's actions to reclaim the throne; the third chronicles the threat of the impending winter, as well as the legendary creatures and fierce peoples of the North...",
                    ReleaseDate = DateTime.Parse("2011-04-11"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Breaking Bad",
                    Description = "Set in Albuquerque, New Mexico, between 2008 and 2010,[12] Breaking Bad follows Walter White, a meek high school chemistry teacher who transforms into a ruthless player in the local methamphetamine drug trade, driven by a " +
                    "desire to financially provide for his family after being diagnosed with terminal lung cancer. Initially making only small batches of meth with his former student Jesse Pinkman in a rolling meth lab, Walter and Jesse eventually expand to make " +
                    "larger batches of a special blue meth that is incredibly pure and creates high demand....",
                    ReleaseDate = DateTime.Parse("2008-01-20"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "The Big Bang Theory",
                    Description = "The show's pilot episode premiered on September 24, 2007. This was the second pilot produced for the show. A different pilot was produced for the 2006–07 television season but never aired. The structure of the original unaired " +
                    "pilot was substantially different from the series' current form. The only main characters retained in both pilots were Leonard (Johnny Galecki) and Sheldon (Jim Parsons), who are named after Sheldon Leonard, a longtime figure in episodic television as producer, director and actor....",
                    ReleaseDate = DateTime.Parse("2007-09-24"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Stranger Things",
                    Description = "Stranger Things is set in the fictional rural town of Hawkins, Indiana, during the early 1980s. The nearby Hawkins National Laboratory ostensibly performs scientific research for the United States Department of Energy, but secretly does experiments into the paranormal " +
                    "and supernatural, including those that involve human test subjects. Inadvertently, they have created a portal to an alternate dimension, \"the Upside Down\". The influence of the Upside Down starts to affect the unknowing residents of Hawkins in calamitous ways....",
                    ReleaseDate = DateTime.Parse("2016-07-16"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Squid Game",
                    Description = "Seong Gi-hun, a divorced and indebted chauffeur, is invited to play a series of children's games for a chance at a large cash prize. Accepting the offer, he is taken to an unknown location where he finds himself among 455 other players who are also deeply in debt. " +
                    "The players are made to wear green tracksuits and are kept under watch at all times by masked guards in pink jumpsuits, with the games overseen by the Front Man, who wears a black mask and black uniform. The players soon discover that losing a game results in their death, with each death adding " +
                    "₩100 million to the potential ₩45.6 billion grand prize.[a] Gi-hun allies with other players, including his childhood friend Cho Sang-woo, to try to survive the physical and psychological twists of the games....",
                    ReleaseDate = DateTime.Parse("2021-09-17"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Another Life",
                    Description = "An unidentified flying object, shaped like a Möbius strip (i.e. an annulus in a hyperbolic plane), lands on Earth and grows a crystalline tower above it. Erik Wallace (Justin Chatwin), a scientist employed by the United States Interstellar Command, attempts to communicate " +
                    "with the alien structure. Wallace's wife, Captain Niko Breckinridge (Katee Sackhoff), takes the spaceship Salvare and its millenial crew to determine the origin of the artifact and establish first contact with the species who sent it...",
                    ReleaseDate = DateTime.Parse("2019-07-25"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "The Witcher",
                    Description = "The show's first season follows Geralt of Rivia, Crown Princess Ciri, and the sorceress Yennefer of Vengerberg at different points of time, exploring formative events that shaped their characters, before eventually merging into a single timeline culminating at the battle for Sodden Hill against the invaders from Nilfgaard...",
                    ReleaseDate = DateTime.Parse("2019-12-20"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Chilling Adventures of Sabrina",
                    Description = "Chilling Adventures of Sabrina is set in the fictional town of Greendale. It is a dark coming-of-age story that includes horror, fear and witchcraft. Sabrina Spellman must reconcile her dual nature as a half-witch, half-mortal while fighting the evil forces that threaten her, her family, and the daylight world humans inhabit...",
                    ReleaseDate = DateTime.Parse("2018-10-26"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "Shadow and Bone",
                    Description = "Grisha are people who can practice the 'Small Science'. Ravka is one of few places they can live safely; there they are trained for the Second Army and divided into three orders. Etherealki summon natural elements like wind or fire, Materialki control materials such as metal and glass, and Corporalki manipulate people’s bodies. " +
                    "Ravka's Second Army is led by General Kirigan, who has spent his life searching for a Grisha who can summon light; the only person who could destroy the Shadow Fold—a region of impenetrable darkness, created hundreds of years ago. Since then, Ravka has been at war, and is now on the brink of splitting in two as the west seeks independence....",
                    ReleaseDate = DateTime.Parse("2021-04-23"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "The Flash",
                    Description = "The first season follows crime-scene investigator Barry Allen who gains super-human speed after the explosion of the S.T.A.R. Labs' particle accelerator which he uses to fight crime and hunt other metahumans in Central City as the Flash, a masked superhero.[1] Barry pursues his mother Nora Allen's murderer Eobard Thawne eventually " +
                    "uncovering that his mentor Harrison Wells is Eobard in disguise. By the end of the season, Eobard's ancestor Eddie sacrifices himself to erase Eobard from existence only to open a singularity in the process. ...",
                    ReleaseDate = DateTime.Parse("2014-10-07"),
                    TypeId = tvShow,
                },
                new Media {
                    Title = "House",
                    Description = "TheIn 2004, David Shore and Paul Attanasio, along with Attanasio's business partner Katie Jacobs, pitched the series (untitled at the time) to Fox as a CSI-style medical detective program,[5] a hospital whodunit in which the doctors investigated symptoms and their causes.[6] Attanasio was inspired to develop a medical procedural " +
                    "drama by The New York Times Magazine column, \"Diagnosis\", written by physician Lisa Sanders, who is an attending physician at Yale–New Haven Hospital (YNHH); the fictitious Princeton–Plainsboro Teaching Hospital (PPTH, not to be confused with the University Medical Center of Princeton at Plainsboro) is modeled after this teaching institution...",
                    ReleaseDate = DateTime.Parse("2004-11-04"),
                    TypeId = tvShow,
                }
            };

            foreach (var movie in movies)
            {
                context.Medias.Add(movie);
            }

            context.SaveChanges();

            if (context.ActorMedias.Any())
            {
                return;   // DB has been seeded
            }

            var cast = context.Actors;
            var actorMedia = new List<ActorMedia>();

            // randomly seed actors for shows and movies
            context.Medias.ToList().ForEach(media => {
                Random r = new Random();
                var actorsInShow = cast.OrderBy(x => Guid.NewGuid()).Take(r.Next(2, 5));
                actorsInShow.ToList().ForEach(actor =>
                {
                    var entry = new ActorMedia() {
                        ActorId = actor.Id,
                        MediaId = media.Id
                    };

                    actorMedia.Add(entry);
                });
            });

            foreach (var ac in actorMedia)
            {
                context.ActorMedias.Add(ac);
            }

            context.SaveChanges();
        }
    }
}
