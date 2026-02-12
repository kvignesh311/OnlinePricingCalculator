import { useState, useEffect } from 'react';
import { fetchItems } from '../api/itemsApi';
import { Item } from '../types';

interface UseItemsReturn {
  items: Item[];
  loading: boolean;
  error: string | null;
  refetch: () => Promise<void>;
}

/**
 * Custom hook to fetch and manage items from the API
 */
export const useItems = (): UseItemsReturn => {
  const [items, setItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  const loadItems = async () => {
    try {
      setLoading(true);
      setError(null);
      const data = await fetchItems();
      setItems(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  return {
    items,
    loading,
    error,
    refetch: loadItems,
  };
};
