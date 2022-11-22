const apiUrl = 'https://localhost:55000/api';

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
