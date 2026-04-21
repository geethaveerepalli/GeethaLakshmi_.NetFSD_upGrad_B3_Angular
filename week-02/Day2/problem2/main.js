import { calculateCartTotal } from './cart.js';

const cart = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 }
];

const totalValue = calculateCartTotal(cart);

const invoice = `
${cart.map(product => 
`Product : ${product.name}
Price   : ₹${product.price}
Quantity: ${product.quantity}
Subtotal: ₹${product.price * product.quantity}
---------------------------------------------`
).join("\n")}

TOTAL CART VALUE: ₹${totalValue}
`;

const outputDiv = document.getElementById("output");
outputDiv.textContent = invoice;