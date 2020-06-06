//let ul = document.getElementById('list');
var li;

let addtocurt = document.getElementById('add');
addtocurt.addEventListener('click', AddtoCurt);

function AddtoCurt() {
    let product = document.querySelector('td');
    console.log(product);
    //let td = document.querySelector('td');

    //create li
    li = document.createElement('li');
    let lable = document.createElement('lable');


    //ul.appendChild(label);
    li.appendChild(lable)
    lable.appendChild(product);
    ul.insertBefore(li, ul[0]);
    li.className('visual');
}