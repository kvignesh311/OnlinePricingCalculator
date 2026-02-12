// API Response Types
export interface Item {
  id: number;
  code: string;
  name: string;
  unitPrice: number;
}

// API Request Types
export interface PricingRequestItem {
  itemId: number;
  quantity: number;
}

export interface PricingRequest {
  items: PricingRequestItem[];
}

// API Response Types
export interface PricingResponseItem {
  itemId: number;
  itemName: string;
  quantity: number;
  unitPrice: number;
  discountAmount: number;
  finalAmount: number;
}

export interface PricingResponse {
  items: PricingResponseItem[];
  totalAmount: number;
}

// Internal State Types
export interface BasketItem {
  itemId: number;
  quantity: number;
}

export interface BasketItemWithDetails extends PricingResponseItem {
  serialNumber: number;
}
