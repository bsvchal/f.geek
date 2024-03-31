const images = [
    "url('../images/background_1.jpg')",
    "url('../images/background_2.jpg')",
    "url('../images/background_3.jpg')"
]

const inner = [
    'Pulp Fiction, 1994',
    'Breaking Bad, 2008',
    'Snowfall, 2017'
];

let i = 0;
function changeTextAndBackground() {
    document.body.style.backgroundImage = images[i];
    document.getElementById('BackgroundTitle').textContent = inner[i];
    i = (i + 1) % inner.length;
}

const button = document.getElementById('switchButton');
const registration = document.getElementById('registration');
const authorization = document.getElementById('authorization');
button.addEventListener('click', () => {
    if (registration.style.display === "none") {
        button.value = "Already have account?\nSign in";
        registration.style.display = "block";
        authorization.style.display = "none";
        document.getElementById('authorizationEmail').value = '';
        document.getElementById('authorizationPassword').value = '';
    } else {
        button.value = "Don't have account?\nCreate";
        registration.style.display = "none";
        authorization.style.display = "block";
        document.getElementById('registrationEmail').value = '';
        document.getElementById('registrationUsername').value = '';
        document.getElementById('registrationPassword').value = '';
    }
});

setInterval(changeTextAndBackground, 5000);

window.onload = () => {
    button.value = "Don't have account?\nCreate";
    registration.style.display = "none";
    authorization.style.display = "block";
};