function pianist(input) {
    let n =Number(input.shift());
    let pieces = {};
    for (let index = 0; index < n; index++) {
        let song = input.shift();
        let [piece,composer,key] = song.split("|");
        pieces[piece] = {
            composer,
            key
        } 
    }
    while (input[0]!="Stop") {
        let line =input.shift();
        let [command,...others] =line.split("|");
        if(command=="Add"){
            let[piece,composer,key] = others;
            if(pieces[piece]==undefined){
                pieces[piece]={
                    composer,
                    key
                }
                console.log(`${piece} by ${composer} in ${key} added to the collection!`);
            }else{
                console.log(`${piece} is already in the collection!`);
            }
        }else if(command=="Remove") {
            let [piece] = others;
            if(pieces[piece]!=undefined){
                delete pieces[piece];
                console.log(`Successfully removed ${piece}!`);
            }else{
                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            }
        }else if (command=="ChangeKey"){
            let [piece,newKey]=others;
            if(pieces[piece]!=undefined){
                pieces[piece].key =newKey;
                console.log(`Changed the key of ${piece} to ${newKey}!`);

            }else{
                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            }
        }
    }

    let sorted = Object.entries(pieces);
    sorted.sort((a,b)=>a[0].localeCompare(b[0]))||a[1].composer.localeCompare(b[1].composer);
    
    for (let song of sorted) {
        console.log(`${song[0]} -> Composer: ${song[1].composer}, Key: ${song[1].key}`);
        
    }
}
pianist([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop']);
    
 pianist([
    '4',
    'Eine kleine Nachtmusik|Mozart|G Major',
    'La Campanella|Liszt|G# Minor',
    'The Marriage of Figaro|Mozart|G Major',
    'Hungarian Dance No.5|Brahms|G Minor',
    'Add|Spring|Vivaldi|E Major',
    'Remove|The Marriage of Figaro',
    'Remove|Turkish March',
    'ChangeKey|Spring|C Major',
    'Add|Nocturne|Chopin|C# Minor',
    'Stop'
  ]
  )   