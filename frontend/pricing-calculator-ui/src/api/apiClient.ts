import axios from 'axios';

// Create axios instance with default configuration
const apiClient = axios.create({
  baseURL: 'https://localhost:7114/api',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor for logging (optional)
apiClient.interceptors.request.use(
  (config) => {
    console.log(`[API Request] ${config.method?.toUpperCase()} ${config.url}`);
    return config;
  },
  (error) => {
    console.error('[API Request Error]', error);
    return Promise.reject(error);
  }
);

// Response interceptor for error handling
apiClient.interceptors.response.use(
  (response) => {
    console.log(`[API Response] ${response.status} ${response.config.url}`);
    return response;
  },
  (error) => {
    if (error.response) {
      // Server responded with error status
      console.error('[API Error Response]', {
        status: error.response.status,
        data: error.response.data,
        url: error.config?.url,
      });
    } else if (error.request) {
      // Request made but no response received
      console.error('[API No Response]', error.message);
    } else {
      // Error in request configuration
      console.error('[API Request Setup Error]', error.message);
    }
    return Promise.reject(error);
  }
);

export default apiClient;
