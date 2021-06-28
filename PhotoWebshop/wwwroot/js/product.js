/**
 * Goes to the cart page.
 * @param {any} productTitle - The title of the product that was clicked on to add to the cart.
 */
function goToCart(productTitle) {
    window.location.href = "/cart?productTitle=" + productTitle;
}