<template>
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
        <tr v-for="(product, index) in products" :key="index">
          <td>{{ product.name }}</td>
          <td>{{ product.unit }}</td>
          <td>{{ product.quantity }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: 'ProductTable',
  computed: {
    products() {
      return this.$store.state.products;
    },
  },
};
</script>

<style>
.table-container {
  display: flex;
  justify-content: center;
}

.product-table {
  width: 60%;
  border-collapse: collapse;
  margin-top: 20px;
}

.product-table th, .product-table td {
  border: 3px solid #ddd;
  padding: 8px;
  text-align: left;
}

.product-table th {
  background-color: #42b983;;
}
</style>
