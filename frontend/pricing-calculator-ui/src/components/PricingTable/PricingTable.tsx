import React from 'react';
import { BasketItemWithDetails } from '../../types';
import styles from './PricingTable.module.css';

interface PricingTableProps {
  items: BasketItemWithDetails[];
  totalAmount: number;
  loading?: boolean;
}

const PricingTable: React.FC<PricingTableProps> = ({ items, totalAmount, loading = false }) => {
  if (items.length === 0 && !loading) {
    return (
      <div className={styles.emptyState}>
        <div className={styles.emptyIcon}></div>
        <p className={styles.emptyText}>Your basket is empty</p>
        <p className={styles.emptySubtext}>Add items to see pricing details</p>
      </div>
    );
  }

  return (
    <div className={styles.tableContainer}>
      <div className={styles.tableWrapper}>
        <table className={styles.table}>
          <thead>
            <tr>
              <th>S. No.</th>
              <th>Item Name</th>
              <th>Quantity</th>
              <th>Rate (₹)</th>
              <th>Discount (₹)</th>
              <th>Final Amount (₹)</th>
            </tr>
          </thead>
          <tbody>
            {loading ? (
              <tr>
                <td colSpan={6} className={styles.loadingCell}>
                  <div className={styles.spinner}></div>
                  <span>Calculating pricing...</span>
                </td>
              </tr>
            ) : (
              items.map((item) => (
                <tr key={item.serialNumber} className={styles.itemRow}>
                  <td>{item.serialNumber}</td>
                  <td className={styles.itemName}>{item.itemName}</td>
                  <td>{item.quantity}</td>
                  <td>{item.unitPrice.toFixed(2)}</td>
                  <td className={styles.discount}>
                    {item.discountAmount > 0 ? (
                      <span className={styles.discountBadge}>
                        -{item.discountAmount.toFixed(2)}
                      </span>
                    ) : (
                      '-'
                    )}
                  </td>
                  <td className={styles.finalAmount}>
                    ₹{item.finalAmount.toFixed(2)}
                  </td>
                </tr>
              ))
            )}
          </tbody>
          <tfoot>
            <tr className={styles.totalRow}>
              <td colSpan={5} className={styles.totalLabel}>
                Total
              </td>
              <td className={styles.totalAmount}>
                ₹{totalAmount.toFixed(2)}
              </td>
            </tr>
          </tfoot>
        </table>
      </div>
    </div>
  );
};

export default PricingTable;
