// (Not Official Method) Billing Calculations via DOM Manipulations

function CalculateTotal() {
    // Getting the fields values
    let productPrice = document.getElementById('productPrice').value
    let clientType = document.getElementById('clientType').value
    let quantity = document.getElementById('productQuantity').value
    // Definig 5% discount, 18% ITBIS to apply and Total Price
    let discount = productPrice * 0.05
    let itbis = productPrice * 0.18
    let totalPrice = 0
    // Defining which client will get the 5% discount
    switch (clientType) {
        case 'Regular':
            totalPrice = parseFloat((productPrice * quantity) + itbis)
            console.log(totalPrice)
            document.getElementById("priceHolder").value = totalPrice;
            break
        case 'Premium':
            totalPrice = parseFloat((productPrice * quantity) + itbis - discount)
            console.log(totalPrice)
            document.getElementById("priceHolder").value = totalPrice;
            break
    }

    var a = document.getElementById("clientType");
    var cust = a.options[a.selectedIndex].text;
    document.getElementById("ClientName").value = cust

    var e = document.getElementById("productPrice");
    var prod = e.options[e.selectedIndex].text;
    document.getElementById("ProductName").value = prod

    var e = document.getElementById("printPartial");
    var prod = e.options[e.selectedIndex].text;
    document.getElementById("Table").value = prod

}

$(document).ready(function () {
    document.querySelector('#collapsed').className = "collapse";
});