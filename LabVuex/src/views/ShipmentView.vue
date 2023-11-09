<template>
  <div class="delivery">
    <h1>Накладна прийому товару</h1>
    <div class="form-container">
      <form @submit.prevent="registerShipment">
        <label for="product-name">Назва товару:</label>
        <input
          style="margin-right: 10px"
          type="text"
          id="product-name"
          v-model="productName"
          required
        />
        <label for="unit">Одиниця виміру:</label>
        <input
          style="margin-right: 10px"
          type="text"
          id="unit"
          v-model="unit"
          required
        />
        <label for="quantity">Кількість:</label>
        <input
          style="margin-right: 10px"
          type="number"
          id="quantity"
          v-model="quantity"
          required
        />
        <button
          style="
            background-color: #42b983;
            color: aliceblue;
            margin-top: 5px;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
          "
          type="submit"
        >
          Зареєструвати надходження
        </button>
      </form>
    </div>

    <div class="table-container">
      <table class="product-table">
        <thead>
          <tr>
            <th>Назва товару</th>
            <th>Одиниця виміру</th>
            <th>Кількість</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(shipment, index) in shipments" :key="index">
            <td>{{ shipment.name }}</td>
            <td>{{ shipment.unit }}</td>
            <td>{{ shipment.quantity }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  name: "ShipmentView",
  data() {
    return {
      productName: "",
      unit: "",
      quantity: 0,
    };
  },
  computed: {
    shipments() {
      return this.$store.state.products;
    },
  },
  methods: {
    registerShipment() {
      this.$store.commit("addShipment", {
        name: this.productName,
        unit: this.unit,
        quantity: this.quantity,
      });
      this.productName = "";
      this.unit = "";
      this.quantity = 0;
    },
  },
};
</script>

<style>
.form-container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.shipment-button {
  margin-top: 10px;
  color: #ffffff;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.shipment-button:hover {
  background-color: #2e856e;
}
</style>
