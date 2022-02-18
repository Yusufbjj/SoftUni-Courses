class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            "child": 150,
            "student": 300,
            "collegian": 500
        };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0
        }

        let conditionNeeded = Object.keys(this.priceForTheCamp).find(k => k === condition);

        if (!conditionNeeded) {
            throw new Error("Unsuccessful registration at the camp.");
        }

        let presentInTheCampAlready = this.listOfParticipants.find(p => p.name === name);

        if (presentInTheCampAlready) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[conditionNeeded]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push(participant);
        return `The ${name} was successfully registered.`;


    }

    unregisterParticipant(name) {

        let participant = this.listOfParticipants.find(p => p.name === name);

        if (!participant) {
            throw new Error(`The ${name} is not registered in the camp.`);
        } else {
            let indexOfParticipant = this.listOfParticipants.indexOf(participant);

            this.listOfParticipants.splice(indexOfParticipant, 1);

            return `The ${name} removed successfully.`;
        }
    }

    timeToPlay(typeOfGame, participant1, participant2) {

        let playerOnePresent = this.listOfParticipants.find(p => p.name === participant1);
        let playerTwoPresent = this.listOfParticipants.find(p => p.name === participant2);

        if (!playerOnePresent) {
            throw new Error(`Invalid entered name/s.`);
        }

        if (participant2) {
            if (playerTwoPresent == undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (playerOnePresent.condition != playerTwoPresent.condition) {
                throw new Error(`Choose players with equal condition.`);
            }
        }

        switch (typeOfGame) {
            case "WaterBalloonFights":
                if (playerOnePresent.power > playerTwoPresent.power) {

                    playerOnePresent.wins++;

                    return `The ${playerOnePresent.name} is winner in the game ${typeOfGame}.`

                } else if (playerOnePresent.power < playerTwoPresent.power) {

                    playerTwoPresent.wins++;

                    return `The ${playerTwoPresent.name} is winner in the game ${typeOfGame}.`;

                } else {
                    return `There is no winner.`;
                }

                break;
            case "Battleship":
                playerOnePresent.power += 20;
                return `The ${playerOnePresent.name} successfully completed the game ${typeOfGame}.`;
                break;
            default:
                break;
        }
    }

    toString() {
        let result = '';

        result += `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        for (let p of this.listOfParticipants.sort((a, b) => b.wins - a.wins)) {
            result += `${p.name} - ${p.condition} - ${p.power} - ${p.wins}\n`;
        }

        return result.trimEnd();
    }

}
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.toString());
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));



