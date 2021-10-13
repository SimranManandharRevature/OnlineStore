const store = document.getElementById("stores")
const welcomeText = document.getElementById("welcome-text")
const productList = document.getElementById("products")



function selectStore() {
  welcomeText.style.display="none"
  fetch(`api/store`)
    .then(r => r.json())
    .then(json => {
      console.log(json)
      json.forEach(e => {
        store.innerHTML += `
              <div class = "store">
              <img onClick=ClickStore(event) data-id="${e.storeId}" src="${e.picture}" alt="product" class="product-img">
              </div>
            `
      })
    });
}

function ClickStore(event) {
  store.style.display = "none";
  let selectedStoreId = parseInt(event.target.dataset.id)
  fetch(`api/Product/storeid=${selectedStoreId}`)
        .then(r => r.json())
    .then(json => {
          console.log(json)
            json.forEach(e => {
                productList.innerHTML += `
              <div class = "product" >
                <img src="${e.picture}" alt="store" class="store-img">
                <h3><span class="name">${e.name}</span> - $<span class="price">${e.price}</span></h3>
                <input type="number" id="quantity" name="quantity" min="1" max="5" step="1" value="1">
                <button onClick=AddToCart(event) data-id="${e.productId}">Add To Cart</button><br>
            </div>
            `
          }) 
        })
}



