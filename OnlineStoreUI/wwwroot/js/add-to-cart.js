const cartItems = document.getElementById("cart-items")
const orderUrl = 'api/order'
const productOrderUrl = 'api/productorder'
const cartBlock = document.getElementById("cart-block")
const totalBlock = document.getElementById("total-block")
const priceBlock = document.getElementById("price-block")
let totalPrice = 0;

function AddToCart(e) {
  // debugger
  let customerId = parseInt(sessionStorage.getItem('customerId'));
  let selectedProductId = parseInt(e.target.dataset.id)
  // productIdArray.push(selectedproductId)
  let productName = e.path[1].childNodes[3].childNodes[0].innerText
  let productPrice = parseInt(e.path[1].childNodes[3].childNodes[2].innerText)
  let quantity = parseInt(e.path[1].childNodes[5].value)

  sessionStorage.setItem('productId', selectedProductId)
  sessionStorage.setItem('ProductName', productName)
  sessionStorage.setItem('ProductPrice', productPrice)

  // debugger
  fetch(orderUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json"
    },
    body: JSON.stringify({
      CustomerId: customerId
    })
  })
    .then(res => res.json())
    .then(data => {
      console.log(data)
      // debugger
      sessionStorage.setItem('orderId', data.orderId)
      totalPrice += (productPrice * quantity);
      cartBlock.style.display="block"
      cartItems.innerHTML += `
        <h4>${productName} - $${productPrice} x ${quantity}</h4> 
      `
      totalBlock.style.display="block"
      priceBlock.innerHTML = `$${totalPrice}
      <button onClick=Checkout(event) id="cart-checkout">Checkout</div>
      `
      let selectProductId = parseInt(sessionStorage.getItem('productId'));
      let selectorderId = parseInt(sessionStorage.getItem('orderId'));
      FetchOrderProduct(selectProductId, selectorderId, quantity)
    })// need to reset this???
  //     sessionStorage.setItem('orderId', data)

  // debugger

//if checkout
  function FetchOrderProduct(selectProductId,selectorderId,quantity){
    fetch(productOrderUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json"
      },
      body: JSON.stringify({
        ProductId: selectProductId,
        OrderId: selectorderId,
        Quantity: quantity
      })
    })
      .then(res => res.json())
      .then(data => {
        console.log(data)
        // debugger
      })
  }   
}

function Checkout(e) {
  let selectorderId = parseInt(sessionStorage.getItem('orderId'));
  fetch(`${orderUrl}/${selectorderId}`)
    .then(res => res.json())
    .then(data => {
      console.log(data)
      // debugger
      window.alert("Congratulations. Your order has been submitted!\nEstimated delivery: 24 hours");
      document.getElementById("cart-container").style.display = "none"
    })
}

function Logout() {
  window.location.reload(false);
}




