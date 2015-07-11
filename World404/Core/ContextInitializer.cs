namespace World404.Core
{
    using System.Data.Entity;
    using System.Linq;
    using Brains;
    using Tangibles;
    using Tangibles.Consumeables;
    using Tangibles.Creatures;

    public class ContextInitializer : DropCreateDatabaseAlways<WorldContext>
    {
        protected override void Seed(WorldContext context)
        {
            var game = new Game();
            game.Seed = null;
            context.Games.Add(game);

            var root = new Area { Owner = null, Name = Generate.Name(10) };
            context.Areas.Add(root);

            var humanic = new Humanic { Name = "Humanic-X1", Node = root };
            context.Humanics.Add(humanic);

            var link = new Link {Humanic = humanic, Type = typeof (SimpleBrain).FullName, Game = game};
            context.Links.Add(link);

            foreach (var sa in Enumerable.Range(0, 5))
            {
                var siblingArea = new Area { Owner = root, Name = Generate.Name(8) };
                context.Areas.Add(siblingArea);

                foreach (var ca in Enumerable.Range(0, 3))
                {
                    var childArea = new Area { Owner = siblingArea, Name = Generate.Name(6) };
                    context.Areas.Add(childArea);

                    foreach (var cn in Enumerable.Range(0, 3))
                    {
                        var childNode = new Node { Owner = childArea, Name = Generate.Name(4) };
                        context.Nodes.Add(childNode);

                        foreach (var ti in Enumerable.Range(0, 5))
                        {
                            var tangible = new Battery {Owner = childNode};
                            context.Tangibles.Add(tangible);
                        }

                        var creature = new Creature {Node = childNode, Type = typeof(BearBehaviour).FullName };
                        context.Tangibles.Add(creature);
                    }
                }
            }
            
            context.SaveChanges();
        }
    }
}