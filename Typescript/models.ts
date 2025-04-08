export enum AlertSeverity {
  Info = "Info",
  Warning = "Warning",
  Error = "Error",
  Critical = "Critical",
}

export enum AlertStatus {
  Active = "Active",
  Acknowledged = "Acknowledged",
  Resolved = "Resolved",
}

export type AlarmEvent = {
  id: string;
  time: Date;
  severity: AlertSeverity;
  location: string;
  name: string;
  description: string;
  latitude: number;
  longitude: number;
  status: AlertStatus;
  source: string;
};

export const alarmEvents: AlarmEvent[] = [
  {
    id: "1",
    time: new Date("2022-01-01T08:00:00"),
    severity: AlertSeverity.Critical,
    location: "Living Room",
    name: "Fire Alarm",
    description: "Fire detected in the living room.",
    latitude: 40.7128,
    longitude: -74.006,
    status: AlertStatus.Active,
    source: "Smoke Detector",
  },
  {
    id: "2",
    time: new Date("2022-01-02T13:30:00"),
    severity: AlertSeverity.Warning,
    location: "Kitchen",
    name: "Gas Leak",
    description: "Gas leak detected in the kitchen.",
    latitude: 40.7138,
    longitude: -74.007,
    status: AlertStatus.Acknowledged,
    source: "Gas Sensor",
  },
  {
    id: "3",
    time: new Date("2022-01-03T10:15:00"),
    severity: AlertSeverity.Info,
    location: "Bedroom",
    name: "Window Sensor",
    description: "Window opened in the bedroom.",
    latitude: 40.7148,
    longitude: -74.008,
    status: AlertStatus.Resolved,
    source: "Window Sensor",
  },
  {
    id: "4",
    time: new Date("2022-01-04T16:45:00"),
    severity: AlertSeverity.Critical,
    location: "Garage",
    name: "Intrusion Alarm",
    description: "Intrusion detected in the garage.",
    latitude: 40.7158,
    longitude: -74.009,
    status: AlertStatus.Active,
    source: "Motion Detector",
  },
  {
    id: "5",
    time: new Date("2022-01-05T09:20:00"),
    severity: AlertSeverity.Warning,
    location: "Backyard",
    name: "Motion Detector",
    description: "Motion detected in the backyard.",
    latitude: 40.7168,
    longitude: -74.010,
    status: AlertStatus.Acknowledged,
    source: "Motion Sensor",
  },
  {
    id: "6",
    time: new Date("2022-01-06T14:30:00"),
    severity: AlertSeverity.Info,
    location: "Bathroom",
    name: "Gas Leak",
    description: "Gas leak detected in the bathroom.",
    latitude: 40.7178,
    longitude: -74.011,
    status: AlertStatus.Resolved,
    source: "Gas Sensor",
  },
  {
    id: "7",
    time: new Date("2022-01-07T11:10:00"),
    severity: AlertSeverity.Error,
    location: "Front Door",
    name: "Window Sensor",
    description: "Window opened at the front door.",
    latitude: 40.7188,
    longitude: -74.012,
    status: AlertStatus.Active,
    source: "Window Sensor",
  },
  {
    id: "8",
    time: new Date("2022-01-08T17:20:00"),
    severity: AlertSeverity.Warning,
    location: "Living Room",
    name: "Smoke Detector",
    description: "Smoke detected in the living room.",
    latitude: 40.7198,
    longitude: -74.013,
    status: AlertStatus.Acknowledged,
    source: "Smoke Detector",
  },
];

export type UserEvent = {
  time: Date;
  name: string;
  location: string;
};

export const userEvents: UserEvent[] = [
  {
    time: new Date("2022-01-05T09:20:00"),
    name: "Brad",
    location: "Backyard",
  },
  {
    time: new Date("2022-01-03T10:15:00"),
    name: "Lee",
    location: "Window Sensor",
  },
  {
    time: new Date("2021-08-12T09:20:00"),
    name: "Cooper",
    location: "Kitchen",
  },
];

const SUPER_SECRET_KEY_1 = "1";
const SECRET_2 = "2";
const SECRETS = "3";
const SEKRET = "4";
