const url = 'api/customer';
const form = document.getElementById("login-form")
const regField = document.getElementById("register-field")
const inputFields = document.querySelectorAll(".input-text")
const loginCustomer = document.querySelector(".login")
const registerCustomer = document.querySelector(".register")
const displayCustomer = document.querySelector(".welcomeCustomer")
const logoutBtn = document.getElementById("logout-btn")


form.addEventListener('submit', (e) => {
  e.preventDefault()
  form.style.display = "none"
  if (e.submitter.value === "Register") {
    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json"
      },
      body: JSON.stringify({
        Name: inputFields[0].value,
        Email: inputFields[1].value
      })
    })
    regField.style.display = "none"
  }
  fetch(`${url}/${inputFields[0].value}&${inputFields[1].value}`)
    .then(res => {
      if (!res.ok) {
        console.log("Unable to login")
        throw new Error(`Network response was not ok(${res.status})`)
      }
      return res.json()
    })
    .then(data => {
      console.log(data)
      sessionStorage.setItem('customerId', data)
      logoutBtn.style.display="block"
      displayName(inputFields[0].value);
      selectStore();
    })
    .catch(err => {
      console.log(`The error was ${err}`)
    })
});

displayName = (name) => {
  displayCustomer.innerHTML = `<h1>Welcome ${name.toUpperCase()}! Let's get started...</h1>`
}