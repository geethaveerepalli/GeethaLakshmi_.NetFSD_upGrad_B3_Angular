export const calculateCartTotal = (products) => {
    return products
        .map(product => product.price * product.quantity)
        .reduce((total, subtotal) => total + subtotal, 0);
};