import React, { useState } from 'react';
import { Item } from '../../types';
import styles from './ItemSelector.module.css';

interface ItemSelectorProps {
  items: Item[];
  onAddItem: (itemId: number, quantity: number) => void;
  disabled?: boolean;
}

const ItemSelector: React.FC<ItemSelectorProps> = ({ items, onAddItem, disabled = false }) => {
  const [selectedItemId, setSelectedItemId] = useState<number>(items[0]?.id || 0);
  const [quantity, setQuantity] = useState<number>(1);

  const handleAdd = () => {
    if (selectedItemId && quantity > 0) {
      onAddItem(selectedItemId, quantity);
      setQuantity(1); // Reset quantity after adding
    }
  };

  const handleQuantityChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = parseInt(e.target.value);
    if (value > 0 || e.target.value === '') {
      setQuantity(value || 0);
    }
  };

  return (
    <div className={styles.container}>
      <div className={styles.formGroup}>
        <label htmlFor="item-select" className={styles.label}>
          Select Item
        </label>
        <select
          id="item-select"
          value={selectedItemId}
          onChange={(e) => setSelectedItemId(Number(e.target.value))}
          className={styles.select}
          disabled={disabled}
        >
          {items.map((item) => (
            <option key={item.id} value={item.id}>
              {item.name} - ₹{item.unitPrice}
            </option>
          ))}
        </select>
      </div>

      <div className={styles.formGroup}>
        <label htmlFor="quantity-input" className={styles.label}>
          Quantity
        </label>
        <input
          id="quantity-input"
          type="number"
          min="1"
          value={quantity}
          onChange={handleQuantityChange}
          className={styles.input}
          disabled={disabled}
        />
      </div>

      <button
        onClick={handleAdd}
        className={styles.addButton}
        disabled={disabled || !selectedItemId || quantity <= 0}
      >
        Add
      </button>
    </div>
  );
};

export default ItemSelector;
