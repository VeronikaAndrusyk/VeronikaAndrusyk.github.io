<template>
  <div>
    <label>Сергій введи свій елемент:</label>
    <input v-model="sergiyInput" type="number">
    <br>
    <label>Микола введи свій елемент:</label>
    <input v-model="mykolaInput" type="number">
    <br>
    <button @click="compareInputs">Порівняти</button>
    <div v-if="winner">
      <p>Переміг: {{ winner }}</p>
      <p>Генероване число комп'ютера: {{ computerNumber }}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      sergiyInput: null,
      mykolaInput: null,
      winner: null,
      computerNumber: null,
    };
  },
  methods: {
    compareInputs() {
      const sergiyDistance = Math.abs(this.sergiyInput - this.computerNumber);
      const mykolaDistance = Math.abs(this.mykolaInput - this.computerNumber);

      if (sergiyDistance < mykolaDistance) {
        this.winner = 'Сергій';
      } else if (mykolaDistance < sergiyDistance) {
        this.winner = 'Микола';
      } else {
        this.winner = 'Нічия';
      }

      this.computerNumber = this.generateRandomNumber();
    },
    generateRandomNumber() {
      return Math.floor(Math.random() * 100) + 1; 
    },
  },
  created() {
    this.computerNumber = this.generateRandomNumber(); // 
  },
};
</script>
