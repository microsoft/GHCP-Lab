import { AlarmEvent, UserEvent } from "./models";

export const alarmEvents: AlarmEvent[] = [
  {
    time: new Date("2022-01-01T08:00:00"),
    severity: "High",
    location: "Living Room",
    name: "Fire Alarm",
  },
  {
    time: new Date("2022-01-05T09:20:00"),
    severity: "Medium",
    location: "Backyard",
    name: "Motion Detector",
  },
  {
    time: new Date("2022-01-02T13:30:00"),
    severity: "Medium",
    location: "Kitchen",
    name: "Gas Leak",
  },
  {
    time: new Date("2022-01-03T10:15:00"),
    severity: "Low",
    location: "Bedroom",
    name: "Window Sensor",
  },
  {
    time: new Date("2022-01-04T16:45:00"),
    severity: "High",
    location: "Garage",
    name: "Intrusion Alarm",
  },
  {
    time: new Date("2022-01-06T14:30:00"),
    severity: "Low",
    location: "Bathroom",
    name: "Gas Leak",
  },
  {
    time: new Date("2022-01-07T11:10:00"),
    severity: "High",
    location: "Front Door",
    name: "Window Sensor",
  },
  {
    time: new Date("2022-01-08T17:20:00"),
    severity: "Medium",
    location: "Living Room",
    name: "Smoke Detector",
  },
];

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

// Use GC inline chat

// #1

// #2
