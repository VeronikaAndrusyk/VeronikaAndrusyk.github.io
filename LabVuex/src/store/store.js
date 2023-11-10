import { createStore } from 'vuex';

export default createStore({
  state: {
    products: [
      { name: 'Олейна', unit: 'шт', quantity: 10 },
      { name: 'Карпатська джерельна', unit: 'шт', quantity: 5 },
      { name: 'Пряники', unit: 'кг', quantity: 20 },
      { name: 'Торчин кетчуп', unit: 'шт', quantity: 15 },
      { name: 'Lay`s', unit: 'шт', quantity: 8 },
      { name: 'Milka', unit: 'шт', quantity: 12 },
    ],
    deliveries: [
      { name: 'Олейна', unit: 'шт', quantity: 10 },
      { name: 'Карпатська джерельна', unit: 'шт', quantity: 5 },
      { name: 'Пряники', unit: 'кг', quantity: 20 },
      { name: 'Торчин кетчуп', unit: 'шт', quantity: 15 },
    ],

  },
  getters: {
    
  },
  mutations: {
    addShipment(state, shipment) {
      state.products.push(shipment);
    },
    addDelivery(state, delivery) {
      state.deliveries.push(delivery);
    },
    deleteProduct(state, index) {
      state.products.splice(index, 1);
    },
  },
  actions: {
    
  },
  modules: {
    
  },
});
