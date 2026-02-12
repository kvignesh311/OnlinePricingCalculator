# Online Pricing Calculator - React Frontend

A production-ready React 19 + TypeScript frontend for the pricing calculator with discount management.

## Tech Stack

- React 19
- TypeScript
- Vite (Build tool)
- Axios (HTTP client)
- CSS Modules (Styling)

## Project Structure

```
pricing-calculator-ui/
├── public/
├── src/
│   ├── api/
│   │   ├── apiClient.ts          # Axios configuration
│   │   ├── itemsApi.ts           # Items API calls
│   │   └── pricingApi.ts         # Pricing calculation API calls
│   ├── components/
│   │   ├── ItemSelector/
│   │   │   ├── ItemSelector.tsx
│   │   │   └── ItemSelector.module.css
│   │   ├── PricingTable/
│   │   │   ├── PricingTable.tsx
│   │   │   └── PricingTable.module.css
│   │   └── ErrorMessage/
│   │       ├── ErrorMessage.tsx
│   │       └── ErrorMessage.module.css
│   ├── types/
│   │   └── index.ts              # TypeScript interfaces
│   ├── hooks/
│   │   └── useItems.ts           # Custom hook for items
│   ├── App.tsx
│   ├── App.module.css
│   ├── main.tsx
│   └── index.css
├── package.json
├── tsconfig.json
├── vite.config.ts
└── README.md
```

## Setup Instructions

### 1. Create the Project

```bash
npm create vite@latest pricing-calculator-ui -- --template react-ts
cd pricing-calculator-ui
```

### 2. Install Dependencies

```bash
npm install
npm install axios
```

### 3. Copy Source Files

Copy all the source files from this package into the `src/` directory.

### 4. Run the Development Server

```bash
npm run dev
```

The application will be available at `http://localhost:5173`

## Build for Production

```bash
npm run build
npm run preview  # Preview production build
```

## API Integration

The app expects two endpoints:

1. **GET** `/api/items` - Fetch available items
2. **POST** `/api/pricing/calculate` - Calculate total with discounts
