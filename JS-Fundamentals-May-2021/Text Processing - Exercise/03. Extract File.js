function extractFile(input) {
    // input= input.split("\\");
    
    // let [file,file2,extension] = input[input.length-1] .split(".");
    // if(extension){
    //     file = file.concat(`.${file2}`);
    //     console.log(`File name: ${file}\nFile extension: ${extension} `);
    // }else{

    //     console.log(`File name: ${file}\nFile extension: ${file2} `);
    // }

    let tokens = input.split("\\");
    let filename = tokens.pop();

    let index = filename.lastIndexOf(".");
    let name = filename.substring(0,index);
    let extension = filename.substring(index+1);
    console.log(`File name: ${name}\nFile extension: ${extension}`);


}
extractFile('C:\\Internal\\training-internal\\Template.pptx');
extractFile('C:\\Projects\\Data-Structures\\LinkedList.cs');
extractFile('C:\\Projects\\Data-Structures\\template.bak.pptx')