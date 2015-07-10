
module World404 {

    interface IIdentifiable {
        ID: string;
    }

    class Identity implements IIdentifiable {
        ID: string;
    }

    class Humanic extends Identity {

        node: Node;
        energy: number;

        constructor(public name: string) {
            super();
        }

    }

    class User {
        humanic: Humanic;
        brain: Brain;
    }

    function Main() {

        var users = [new User(), new User()];

        for (var user in users) {
            TickManager.instance.currentTickUser = users[user];

            TickManager.instance.currentTickUser.brain.tick(TickManager.instance.currentTickUser.humanic);
        }
    }

    class TickManager {

        private static _instance: TickManager;

        static get instance(): TickManager {
            if (!TickManager._instance) {
                TickManager._instance = new TickManager();
            }
            return TickManager._instance;
        }

        currentTickUser: User;
    }

    class Brain extends Identity {

        storage: string[];

        tick(humanic: Humanic) {
            var grain = humanic.node.tangibles[0];

            var gather = grain.commands[0];

            if (gather.ID == "gather") {
                gather.Execute();
            }
        }

    }

    class Tangible extends Identity {
        commands: Command[];
    }

    class Grain extends Tangible {

        commands = [new GatherGrain()]

    }

    class GatherGrain extends Command {

        Execute() {
            this.BaseExecute();
        }

    }

    class Command extends Identity {

        BaseExecute(): void {
            TickManager.instance.currentTickUser.humanic.energy--;
        }

        Execute(): void{
            
        }
    }

    class Intangible extends Identity {

    }

    class Node extends Identity {

        tangibles: Tangible[];
        intangibles: Intangible[];

        parent: Area;

        get siblings(): Node[] {

            return [];
        }

        get humanics(): Humanic[] {

            return [];
        }

    }

    class Area extends Node {

        parent: Region;

        get siblings(): Area[] {

            return [];
        }

        get children(): Node[] {

            return [];
        }

    }

    class Region extends Area {

        parent = null;

        areas: Area[];
    }



}
