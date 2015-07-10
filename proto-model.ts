/**
 * World 404 is a world that is no longer safe. A world that used to exist is no longer there.
 * The world is post-apocalyptic. A world not safe for humans. But to survive, humanics have 
 * been created by humans in underworld bunkers and off-world space ships. 
 * 
 * Thier purpose? To keep the human race alive. Humanics are controlled by programmers, who are 
 * underground where it is safe from the harsh environments above. They can control humanics
 * through writing logic that they beam to their humanics. 
 * 
 * They use computer displays to see what their humanics have discovered and collected. The 
 * computer display is a graph that shows the discovered map area the humanics have uncovered.
 * 
 * displaying a break down of what nodes they have visitied, what area they are in (if visited all nodes in an area).
 * If their huamnic is running low on energy or needs support from other humanics in their faction.
 * 
 * The world is not the same world anymore, with a fight for survival, nobody can be trusted. It's kill or be killed.
 * Defend your faction. 
 * 
 * A tick based game with various options enable for skirmishes, or long running MMO styled games.
 * 
 */
module World404 {

    function Main() {

        var reconBrain = new Brain();
        var reconHumanic = new Humanic("Recon humanic")

        var uploadLinks = [new UploadLink(reconHumanic, reconBrain)]

        for (var link in uploadLinks) {

            TickManager.instance.current = uploadLinks[link];
            TickManager.instance.current.brain.execute(uploadLinks[link].humanic);
        }
    }

    interface IIdentifiable {
        ID: string;
    }

    /**
     * An object in the world that can be identified
     */
    class Identity implements IIdentifiable {
        ID: string;
    }

    /**
     * A creature can be similar to a Humanic, but is Server side AI that navigates through the world.
     * A passive creature may just move from node to node and consume hay and be harmless in the game world.
     * Potenitally be harvestable by humanics.
     */
    class Creature extends Tangible {
        node: Node;
        energy: number;
        mode: CreatureMode;
    }
    
    enum CreatureMode {
        /**
         * This creature does not attack
         */
        Passive,
        /**
         * This creature will attack when being attacked or interacted with
         */
        Defensive,
        /**
         * This creature will attack if other creatures/humanics are in range?
         */
        Aggressive
    }
    
    class Wolf extends Creature {
        
        constructor(){
            super();
            this.mode = CreatureMode.Aggressive;
        }
    }
    
    /**
     * An example server creature AI, that navigates about nodes in the World.
     */
    class CreatureAI {
        
        previous: Node;
        
        execute(creature: Creature) {            
            this.travel(this.previous);
            
            if(creature.node.humanics.length > 0 && creature.mode == CreatureMode.Aggressive){
                // attack 
            }
        }    
        
        private travel(node: Node): void { 
            
            var otherNodes = node.siblings;
            
            for(var other in otherNodes){
                
                var node = otherNodes[other];
                
                // find commands on these nodes
                var nodeCommands = node.commands;
                
                for (var nc in nodeCommands) {
                    
                    var command = nodeCommands[nc];
                    
                    if (command.ID == "goto") {
                        command.Execute();
                    }
                }
            }
            
        }
        
    }

    /**
     * Humanic that moves to different nodes, collects tangibles, performs actions on tangibles
     * makes decisions on intangibles or tangibles in a node
     * can be part of a faction or collective e.g a Team, Guild.
     */
    class Humanic extends Tangible {

        node: Node; // what position this humanic is at in the world
        energy: number; // the energy level of the humanic
        tangibles: Tangible[]; // e.g inventory or collected items

        /**
         * The name of the humanic.
         */
        constructor(public name: string) {
            super();
        }
    }

    /**
     * Uploaded DLL with selected humanic (created online, dropdown of humanic for dll to be used for specific humanic)
     */
    class UploadLink {

        constructor(public humanic: Humanic, public brain: Brain) {

        }
    }    

    /**
     * Some form of managing the current user to perform their execute function on
     * during a server tick.
     * 
     * A server tick will occur N times apart. When a tick happens, all nodes with 
     * objects that decay, move or have state should tick. 
     * 
     * E.g water wells may be full, but over the course of a long running game like a week
     * each server tick introduces the water to evaporate, meaning the item may eventually
     * be deleted if no humanics found the water to collect. 
     * 
     */
    class TickManager {

        private static _instance: TickManager;

        current: UploadLink;

        static get instance(): TickManager {

            if (!TickManager._instance) {
                TickManager._instance = new TickManager();
            }
            return TickManager._instance;
        }
    }

    /**
     * This will be what the dll will contain.
     * A simple class that impmentents from IBrain
     * IBrain will be part of the SDK, a developer implements the IBrain 
     * Their implementation will be instatiated on the server side and will be used
     * for a chosen humanic of their choice, a humanic they would have created online
     * using the website. 
     * 
     * The execute method will be called per server tick. 
     */
    class Brain extends Identity {

        meta: string[]; // they can use anything simple like storing found objects 
        previousTick = 0;
        tick = 0;
        
        execute(humanic: Humanic) {
              
            // explore current node              
            var nodeTangibles = humanic.node.tangibles;
            
            var currentNode = humanic.node;
            var nodeCommands = currentNode.commands;
            
            // perform some recon commands at the current position
            for(var c in nodeCommands) {
                
                var command = nodeCommands[c];
                
                if(command.ID == "scan") {
                    command.Execute(); // scan for any signals sent to this node.
                    // unsure of what it would do but example of other commands
                }
                
                if(command.ID == "leave note") {
                    command.Execute()
                }
            }

            for (var tn in nodeTangibles) {

                var tangible = nodeTangibles[tn];
                var tangibleCommands = tangible.commands;
                
                // explore commands on tangible
                for (var ci in tangibleCommands) {

                    var command = tangibleCommands[ci];
                                
                    // find interesting command
                    if (command.ID == "gather") {
                        
                        // use command
                        command.Execute();
                    }
                }
            }

            // use items in inventory
            var inventoryItems = humanic.tangibles;

            for (var i in inventoryItems) {

                var item = inventoryItems[i];
                
                var itemCommands = item.commands;

                for (var c in itemCommands) {

                    var command = itemCommands[c];

                    if (command.ID == "consume") {
                        command.Execute();
                    }
                }
            }
            
            // navigate sibling nodes            
            var otherNodes = humanic.node.siblings;
            
            for(var other in otherNodes){
                
                var node = otherNodes[other];
                
                // find commands on these nodes
                var nodeCommands = node.commands;
                
                for (var nc in nodeCommands) {
                    
                    var command = nodeCommands[nc];
                    
                    if (command.ID == "goto") {
                        command.Execute();
                    }
                    
                    if(command.ID == "signal") {
                        // maybe send a signal to sibling nodes, get in contact with other humanics
                    }
                }
            }

            this.previousTick = this.tick;
            this.tick++;
        }
    }

    /**
     * A command has an owner and an Execute method.
     * The ICommand is unique per Humanic Context.
     * When the execute method is called, it should only
     * affect the humanic which called the execute method.
     * 
     * The owner will generally be something like a Structure, Vehicle, Weapon or other Humanic (any Tangible really)
     * Sometimes, it will make sense to destroy the owner, it all depends on what the command will do.
     * E.g, if the command is Open, then it will Open the Tangible. IF the command is "eat", then the tangible could be
     * deleted from the database since it was "consumed", again - it will depend on implementation of commmand.
     */
    interface ICommand {
        owner: Tangible;
        Execute(): void;
    }

    /**
     * A tangible is any object in the "world" that humanics or other server AI can interact with.
     * Interactions with physical objects are performed via the objects "Commands".
     */
    class Tangible extends Identity {
        commands: Command[];
        owner: Tangible;
    }

    /**
     * An example of a Tangible object.
     * The tangible object has its own unique set of commands. 
     */
    class Battery extends Tangible {
        commands = [new GatherBatteryCommand(this), ]
    }

    class Command extends Identity implements ICommand {

        constructor(public owner: Tangible) {
            super();
        }

        Execute(): void {

        }
    }

    /**
     * This command is a demonstration of what a Battery command may do.
     * This command knows the current humanic executing the command
     * So knows that the humanic picked up the battery and then this
     * item is placed into the humanics "inventory", the inventory is just another collection of Tangibles, 
     * where those tangibles "owner" is the Humanic, not the Node that they were originally from. (if picked up)
     */
    class GatherBatteryCommand extends Command {

        public Execute(): void {
            var battery = this.owner;
            battery.owner = TickManager.instance.current.humanic;
        }
    }

    /**
     * Another example command on Tangible object Battery
     * This increases the battery life of the humanic by 1.
     */
    class ConsumeBatteryCommand extends Command {

        Execute() {
            
            // since the huamic energy has gone up
            TickManager.instance.current.humanic.energy++;
            
            // we can destory the owner, this would essentially be like a Database.Delete(this.owner)
            // since this battery should no longer exist in the game world. 
            this.owner = null; 
            
        }
    }

    /**
     * Intangibles are things that have properties,
     * but are not executeable, for example a Faction
     * or a temperature in a node. Unsure how many 
     * objects in the game world would be Intangible
     * but certain Tangible objects may have descriptive
     * properties like what material they are made out of,
     * they could be displayed via Intangible properties.
     * 
     * Certain tangibles could be dangerous, and there may be 
     * information that intangible properties can provide.
     * 
     * E.g an area might be dense forest - difficult to navigate,
     * any nodes inside might have a lot of items, but could contain
     * dangerous creatures, since there is dense forest. 
     * 
     */
    class Intangible extends Identity {
        
    }

    /**
     * A node contains items (Tangibles)
     * A node itself is Tangible, because it has Commands, is physically interactable with by humanics or AI.
     * A Node would generally be an explorable with various tangibles. (Police station, Coffee shop, News Agent)
     */
    class Node extends Tangible {

        tangibles: Tangible[]; // Tangibles, batteries, weapons, energy resources, Houses, Police stations
        intangibles: Intangible[]; // Dense forest, light forestation, cold temperature 
        
        // A node exists within an area, an Area could be a Town, or a County or a Field
        // A field could have many barns. Each barn could be a node. A barn could have tangibles like Hay, Horse, Water Well.
        
        parent: Area;

        get siblings(): Node[] {
            return [];
        }

        get humanics(): Humanic[] {
            return [];
        }
    }

    /**
     * Either a region consisting of smaller areas or fields.
     */
    class Area extends Node {
        
        tangibles: Tangible[]; // Could contain same items as Node Tangibles, maybe cheaper or less useful.
        

        // If the parent area is Null. 
        // Then this is the edge of the known world space. 
        // As more humanics or players enter the world
        // the server may dynamically create extensions 
        // onto the outer most areas of the world. 
        // This would then mean that the Parent would be set on an Area
        // whos parent would usually be null, but the world expanded.
        parent: Area;

        // other neighbouring areas (other counties for example)
        get siblings(): Area[] {
            return [];
        }
        
        get children(): Node[] {
            return [];
        }
    }
}
