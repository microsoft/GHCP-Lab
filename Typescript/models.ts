export interface ICar {
  id: string;
  make: string;
  model: string;
  year: number;
  value: number;
  condition: "new" | "used";
}
