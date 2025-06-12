class Point3D {
    private x: number;
    private y: number;
    private z: number;

    constructor(x: number, y: number, z: number) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Get the X coordinate
    getX(): number {
        return this.x;
    }

    // Get the Y coordinate
    getY(): number {
        return this.y;
    }

    // Get the Z coordinate
    getZ(): number {
        return this.z;
    }

    // Set the X coordinate
    setX(x: number): void {
        this.x = x;
    }

    // Set the Y coordinate
    setY(y: number): void {
        this.y = y;
    }

    // Set the Z coordinate
    setZ(z: number): void {
        this.z = z;
    }

    // Calculate the distance to another point
    distanceTo(other: Point3D): number {
        const dx = this.x - other.getX();
        const dy = this.y - other.getY();
        const dz = this.z - other.getZ();
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }

    // Convert the point to a string representation
    toString(): string {
        return `(${this.x}, ${this.y}, ${this.z})`;
    }
}