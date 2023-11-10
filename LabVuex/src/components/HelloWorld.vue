<template>
  <div class="table-container">
    <label for="filter">Фільтр:</label>
    <input type="text" id="filter" v-model="filterText" />

    <table class="product-table">
      <thead>
        <tr>
          <th @click="sort('name')">Назва товару</th>
          <th @click="sort('unit')">Одиниця виміру</th>
          <th @click="sort('quantity')">Кількість</th>
          <th>Дії</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(product, index) in filteredProducts" :key="index">
          <td>{{ product.name }}</td>
          <td>{{ product.unit }}</td>
          <td>{{ product.quantity }}</td>
          <td>
            <button @click="deleteProduct(index)">Видалити</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "ProductTable",
  data() {
    return {
      filterText: "",
      sortColumn: null,
      sortOrder: 1,
    };
  },
  computed: {
    products() {
      return this.$store.state.products;
    },
    filteredProducts() {
      const filterText = this.filterText.toLowerCase();
      return this.products
        .filter((product) =>
          Object.values(product).some((value) =>
            value.toString().toLowerCase().includes(filterText)
          )
        )
        .sort(
          (a, b) =>
            (this.sortColumn ? a[this.sortColumn] > b[this.sortColumn] : 0) *
            this.sortOrder
        );
    },
  },
  methods: {
    deleteProduct(index) {
      this.$store.commit("deleteProduct", index);
    },
    sort(column) {
      if (this.sortColumn === column) {
        this.sortOrder *= -1;
      } else {
        this.sortColumn = column;
        this.sortOrder = 1;
      }
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

.product-table th,
.product-table td {
  border: 3px solid #ddd;
  padding: 8px;
  text-align: left;
}

.product-table th {
  background-color: #42b983;
}
.filter-button {
  padding: 8px 12px;
  font-size: 14px;
  border: 1px solid #42b983;
  background-color: #42b983;
  color: #ffffff;
  border-radius: 4px;
  cursor: pointer;
}

.filter-button:hover {
  background-color: #2e856e;
}
</style>
