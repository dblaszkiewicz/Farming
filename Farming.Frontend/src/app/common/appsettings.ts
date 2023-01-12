const apiUrl = 'https://localhost:7001/api';
// TODO: zrobic production.json i development.json -> w app.module zrobic inicjalizacje serwisu w ktorym ustawiam apiUrl

export const AppSettings = {
  apiUrl: apiUrl,
  fertilizerEndpoint: `${apiUrl}/Fertilizer`,
  fertilizerWarehouseEndpoint: `${apiUrl}/FertilizerWarehouse`,
  pesticideEndpoint: `${apiUrl}/Pesticide`,
  pesticideWarehouseEndpoint: `${apiUrl}/PesticideWarehouse`,
  plantEndpoint: `${apiUrl}/Plant`,
  plantWarehouseEndpoint: `${apiUrl}/PlantWarehouse`,
  seasonEndpoint: `${apiUrl}/Season`,
  seedEndpoint: `${apiUrl}/Seed`,
  landEndpoint: `${apiUrl}/Land`,
  weatherEndpoint: `${apiUrl}/Weather`,
  userEndpoint: `${apiUrl}/User`,
  authEndpoint: `${apiUrl}/auth`,
  seedSampleData: `${apiUrl}/SampleDataSeed`,
};
