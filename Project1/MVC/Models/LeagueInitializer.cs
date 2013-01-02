using System.Collections.Generic;
using System.Data.Entity;

namespace BootstrapExample.Models
{
    public class LeagueInitializer : DropCreateDatabaseIfModelChanges<LeagueContext>
    {
        protected override void Seed(LeagueContext context)
        {
            var positionList = new List<Position>
                {
                    new Position
                        {
                            Name = "Pitcher"
                        },
                    new Position
                        {
                            Name = "Catcher"
                        },
                    new Position
                        {
                            Name = "First Base"
                        },
                    new Position
                        {
                            Name = "Second Base"
                        },
                    new Position
                        {
                            Name = "Third Base"
                        },
                    new Position
                        {
                            Name = "Shortstop"
                        },
                    new Position
                        {
                            Name = "Left Field"
                        }
                        ,
                    new Position
                        {
                            Name = "Center Field"
                        },
                    new Position
                        {
                            Name = "Right Field"
                        }
                };

            positionList.ForEach(position => context.Positions.Add(position));

            context.Teams.Add(new Team
            {
                Name = "Default Team",
                Players = new List<Player>()
                {
                      new Player{ Name="Jonny Mantis", Number= 13, Position = positionList[0]}
                }
            });

            context.SaveChanges();
        }
    }
}