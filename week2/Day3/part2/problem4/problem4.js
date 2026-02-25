const products = [
    "Apple iPhone 14",
    "Samsung Galaxy S23",
    "OnePlus 11",
    "Sony Headphones",
    "Dell Laptop",
    "HP Printer",
    "Logitech Mouse",
    "Nike Sneakers",
    "Adidas T-shirt"
];

const searchInput = document.getElementById('searchInput');
const productList = document.getElementById('productList');

function renderProducts(items) {

    productList.innerHTML = "";

    if (items.length === 0) {
        const li = document.createElement('li');
        li.textContent = "No Results Found";
        li.classList.add('no-results');
        productList.appendChild(li);
        return;
    }

    items.forEach(product => {
        const li = document.createElement('li');
        li.textContent = product;
        productList.appendChild(li);
    });
}

function filterProducts(query) {
    const filtered = products.filter(product =>
        product.toLowerCase().includes(query.toLowerCase())
    );
    renderProducts(filtered);
}

productList.addEventListener('click', (e) => {
    if (e.target.tagName === 'LI' && !e.target.classList.contains('no-results')) {
        alert(`You selected: ${e.target.textContent}`);
    }
});

searchInput.addEventListener('input', (e) => {
    filterProducts(e.target.value);
});

renderProducts(products);