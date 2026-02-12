import React, { useState } from 'react';
import ItemSelector from './components/ItemSelector/ItemSelector';
import PricingTable from './components/PricingTable/PricingTable';
import ErrorMessage from './components/ErrorMessage/ErrorMessage';
import { useItems } from './hooks/useItems';
import { calculatePricing } from './api/pricingApi';
import { BasketItem, BasketItemWithDetails } from './types';
import styles from './App.module.css';

function App() {
  const { items, loading: itemsLoading, error: itemsError, refetch } = useItems();
  const [basket, setBasket] = useState<BasketItem[]>([]);
  const [pricingDetails, setPricingDetails] = useState<BasketItemWithDetails[]>([]);
  const [totalAmount, setTotalAmount] = useState<number>(0);
  const [calculating, setCalculating] = useState<boolean>(false);
  const [pricingError, setPricingError] = useState<string | null>(null);

  const handleAddItem = async (itemId: number, quantity: number) => {
    try {
      setPricingError(null);
      setCalculating(true);

      // Check if item already exists in basket
      const existingItemIndex = basket.findIndex(item => item.itemId === itemId);
      let updatedBasket: BasketItem[];

      if (existingItemIndex !== -1) {
        // Update quantity if item exists
        updatedBasket = basket.map((item, index) =>
          index === existingItemIndex
            ? { ...item, quantity: item.quantity + quantity }
            : item
        );
      } else {
        // Add new item to basket
        updatedBasket = [...basket, { itemId, quantity }];
      }

      // Calculate pricing with updated basket
      const pricingResponse = await calculatePricing({ items: updatedBasket });

      // Update state with new pricing details
      const itemsWithSerialNumbers = pricingResponse.items.map((item, index) => ({
        ...item,
        serialNumber: index + 1,
      }));

      setBasket(updatedBasket);
      setPricingDetails(itemsWithSerialNumbers);
      setTotalAmount(pricingResponse.totalAmount);
    } catch (error) {
      console.error('Error adding item:', error);
      setPricingError(error instanceof Error ? error.message : 'Failed to add item');
    } finally {
      setCalculating(false);
    }
  };

  if (itemsLoading) {
    return (
      <div className={styles.container}>
        <div className={styles.loadingContainer}>
          <div className={styles.loader}></div>
          <p className={styles.loadingText}>Loading items...</p>
        </div>
      </div>
    );
  }

  if (itemsError) {
    return (
      <div className={styles.container}>
        <ErrorMessage message={itemsError} onRetry={refetch} />
      </div>
    );
  }

  return (
    <div className={styles.container}>
      <header className={styles.header}>
        <h1 className={styles.title}>Online Pricing Calculator</h1>
        <p className={styles.subtitle}>Add items to your basket and see real-time pricing with discounts</p>
      </header>

      <main className={styles.main}>
        <ItemSelector
          items={items}
          onAddItem={handleAddItem}
          disabled={calculating}
        />

        {pricingError && (
          <ErrorMessage message={pricingError} />
        )}

        <PricingTable
          items={pricingDetails}
          totalAmount={totalAmount}
          loading={calculating}
        />
      </main>

      <footer className={styles.footer}>
        <p>© 2026 Pricing Calculator | Discounts applied automatically</p>
      </footer>
    </div>
  );
}

export default App;
