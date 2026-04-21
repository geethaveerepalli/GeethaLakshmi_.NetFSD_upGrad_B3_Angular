const feedbackBtn = document.getElementById('feedbackBtn');
const feedbackInput = document.getElementById('feedbackInput');
const confirmationMessage = document.getElementById('confirmationMessage');
feedbackBtn.addEventListener('click', () => {
    const userFeedback = feedbackInput.value.trim();

    if (userFeedback === "") {
        confirmationMessage.textContent = "Please enter some feedback!";
        confirmationMessage.style.color = "red";
    } else {
        confirmationMessage.textContent = `Thank you for your feedback: "${userFeedback}" `;
        confirmationMessage.style.color = "green";
        feedbackInput.value = "";
    }

    setTimeout(() => {
        confirmationMessage.textContent = "";
    }, 3000);
});