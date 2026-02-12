import apiClient from './apiClient';
import { Item } from '../types';

/**
 * Fetch all available items from the backend
 */
export const fetchItems = async (): Promise<Item[]> => {
  try {
    const response = await apiClient.get<Item[]>('/items');
    return response.data;
  } catch (error) {
    console.error('Error fetching items:', error);
    throw new Error('Failed to fetch items. Please check your connection and try again.');
  }
};
