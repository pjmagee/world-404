namespace World404
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Core;
    using Tangibles;

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new ContextInitializer());

            using (var context = new WorldContext())
            {
                var areas = context.Areas.ToList();

                foreach (var area in areas)
                {
                    Console.WriteLine($"{area} is owned by {area.Owner}.");
                    
                    PrintSiblings(area);
                    PrintHumanics(area);
                    PrintAreaChildren(area);
                }

                PrintHumanics(context);
            }

            Console.ReadLine();
        }

        private static void PrintHumanics(WorldContext context)
        {
            var humanics = context.Humanics.ToList();

            foreach (var humanic in humanics)
            {
                Console.WriteLine($"{humanic}");
            }
        }

        private static void PrintAreaChildren(Area area)
        {
            Console.WriteLine($"{area} has {area.Children.Count} children.");

            foreach (var node in area.Children)
            {
                Console.WriteLine($"{node} is owned by {node.Owner}.");
                PrintNodeSiblings(area, node);
                PrintNodeTangibles(node);
                PrintNodeInTangibles(node);
            }
        }

        private static void PrintNodeTangibles(Node node)
        {
            Console.WriteLine($"{node} has {node.Tangibles.Count} tangibles.");

            foreach (var tangible in node.Tangibles)
            {
                Console.WriteLine($"{tangible} is in {node}");
                PrintTangibleCommands(tangible);
            }
        }

        private static void PrintNodeInTangibles(Node node)
        {
            Console.WriteLine($"{node} has {node.Intangibles.Count} intangibles.");

            foreach (var intangible in node.Intangibles)
            {
                Console.WriteLine($"{intangible}");
            }
        }

        private static void PrintTangibleCommands(Tangible tangible)
        {
            Console.WriteLine($"{tangible} has {tangible.Commands.Count()} commands.");

            foreach (var command in tangible.Commands)
            {
                Console.WriteLine($"{command} is owned by {command.Owner}.");
            }
        }

        private static void PrintNodeSiblings(Area area, Node node)
        {
            Console.WriteLine($"{node} has {node.Siblings.Count} siblings.");
            foreach (var sibling in node.Siblings)
            {
                Console.WriteLine($"{sibling} is owned by {sibling.Owner}.");
                Console.WriteLine($"{area} has {area.Siblings.Count} siblings.");
            }
        }

        private static void PrintHumanics(Area area)
        {
            Console.WriteLine($"{area} has {area.Tangibles.Count(x => x is Humanic)} humanics.");
            foreach (var humanic in area.Tangibles.OfType<Humanic>())
            {
                Console.WriteLine($"{humanic} is in {area}");
            }
        }

        private static void PrintSiblings(Area area)
        {
            Console.WriteLine($"{area} has {area.Siblings.Count} siblings.");
            foreach (var sibling in area.Siblings.OfType<Area>())
            {
                Console.WriteLine($"{sibling} is owned by {sibling.Owner}.");
                Console.WriteLine($"{sibling} has {sibling.Children.Count} children.");
                Console.WriteLine($"{area} has {area.Siblings.Count} siblings.");
            }
        }
    }
}
