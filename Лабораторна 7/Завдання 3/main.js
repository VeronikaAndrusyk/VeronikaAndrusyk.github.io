
function calculate() {
  var price = document.getElementById("price").value;
  var weight = document.getElementById("weight").value;
  var insurance = document.getElementById("insurance").checked;
  var deliveryCost;
  
  if (weight <= 2) {
    deliveryCost = 40;
  } else if (weight <= 10) {
    deliveryCost = 60;
  } else if (weight <= 30) {
    deliveryCost = 80;
  } else {
    alert("Нажаль, ми не можемо доставити товар вагою більше 30 кг.");
    return;
  }
  
  if (insurance) {
    var insuranceCost = price * 0.02;
    deliveryCost += insuranceCost;
  }
  
  var totalCost = deliveryCost.toFixed(2);
  
  document.getElementById("result").innerHTML = "Вартість доставки: " + totalCost + " грн.";
}
