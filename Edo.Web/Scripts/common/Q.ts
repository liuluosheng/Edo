namespace Q {
    export class LT {
        public static itData: any
        public static getText(key: string) {
            return this.itData[key];
        }
    }

    export function Text(key: string) {
        return LT.getText(key);
    }
} 