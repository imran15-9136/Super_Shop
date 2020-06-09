//let ul = document.getElementById('list');
var li;

//let addtocurt = document.querySelector('.addtoCart');
//addtocurt.addEventListener('click', AddtoCurt);

function AddtoCurt(id, name, price) {

    let product{
        product_id: id,
        product_name: name,
        product_price: price,
        product_quantity:1
    }

    let product_list = [];
    product_list.push(product);

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

$(document).on("click", ".addtoCart", function () {
    var id = this.id
    let name = $(this).attr("data-name")
    let price = $(this).attr("data-price")

    AddtoCurt(id,name,price);
});