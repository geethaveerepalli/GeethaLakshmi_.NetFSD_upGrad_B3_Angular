const marks = [78, 85, 92, 60, 55];

const formattedMarks = marks.map(mark => Number(mark));

const calculateTotal = (arr) =>
    arr.reduce((sum, mark) => sum + mark, 0);

const calculateAverage = (arr) =>
    calculateTotal(arr) / arr.length;

const getResult = (average) =>
    average >= 50 ? "PASS" : "FAIL";

const totalMarks = calculateTotal(formattedMarks);
const averageMarks = calculateAverage(formattedMarks);
const result = getResult(averageMarks);

const outputDiv = document.getElementById("output");

outputDiv.innerHTML = `
    <p><strong>Marks:</strong> ${formattedMarks.join(", ")}</p>
    <p><strong>Total Marks:</strong> ${totalMarks}</p>
    <p><strong>Average Marks:</strong> ${averageMarks.toFixed(2)}</p>
    <p><strong>Result:</strong> ${result}</p>
`;