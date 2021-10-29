class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer,
        this.location = location,
        this.priceForTheCamp = {
            "child": 150, 
            "student": 300, 
            "collegian": 500
        },
        this.listOfParticipants = [] 
    }

    registerParticipant(name, condition, money){
        if(!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if(this.listOfParticipants.some(p => p.name === name)) {
            return `The ${name} is already registered at the camp.`
        }

        if(this.priceForTheCamp[condition] > money) {
            return `The money is not enough to pay the stay at the camp.`
        }

        this.listOfParticipants.push({
            name, 
            condition, 
            power: 100, 
            wins: 0
        });

        return `The ${name} was successfully registered.`;
    };

    unregisterParticipant(name) {

        let participant = this.listOfParticipants.find(p => p.name === name)

        if(participant == undefined) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }
        var indexOfParticipant = this.listOfParticipants.map(function(p) { return p.name; }).indexOf(name);

        this.listOfParticipants.splice(indexOfParticipant, 1);

        return `The ${name} removed successfully.`
    };

    timeToPlay(typeOfGame, participant1, participant2) {
        let firstParticipant = this.listOfParticipants.find(p => p.name === participant1);
        let secondParticipant = this.listOfParticipants.find(p => p.name === participant2);

        if(typeOfGame === 'WaterBalloonFights') {
            if(firstParticipant == undefined || secondParticipant == undefined) {
                throw new Error('Invalid entered name/s.');
            }
            if(firstParticipant.condition != secondParticipant.condition) {
                throw new Error('Choose players with equal condition.');
            }
            
            let haswinner = firstParticipant.power != secondParticipant.power ? true : false

            if(haswinner) {
                let winner = firstParticipant.power > secondParticipant.power ? firstParticipant : secondParticipant;
                winner.wins += 1;

                return `The ${winner.name} is winner in the game ${typeOfGame}.`
            }
            
            return `There is no winner.`;
        } 
        else if(typeOfGame === 'Battleship') {
            if(firstParticipant == undefined) {
                throw new Error('Invalid entered name/s.');
            }

            firstParticipant.power += 20;

            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        }
    };

    toString() {
        let output = [];
        output.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);
       
        let sortedListOfParticipants = this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        
        for(let participant of sortedListOfParticipants) {
            output.push(`${participant.name} - ${participant.condition} - ${participant.power} - ${participant.wins}`);
        }

        return output.join('\n');
    }
}

//const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
//console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
//console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
//console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
//console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

//console.log(summerCamp.unregisterParticipant("Petar"));
//console.log(summerCamp.unregisterParticipant("Petar Petarson"));

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

