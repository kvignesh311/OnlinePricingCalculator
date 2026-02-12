import apiClient from './apiClient';
import { PricingRequest, PricingResponse } from '../types';

/**
 * Calculate pricing with discounts for the given basket items
 */
export const calculatePricing = async (
  request: PricingRequest
): Promise<PricingResponse> => {
  try {
    const response = await apiClient.post<PricingResponse>(
      '/pricing/calculate',
      request
    );
    return response.data;
  } catch (error) {
    console.error('Error calculating pricing:', error);
    throw new Error('Failed to calculate pricing. Please try again.');
  }
};
