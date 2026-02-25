/**
 * GS1 EPC Tag Data Translation Engine (WebAssembly).
 *
 * Licensed under BSL 1.1 -- production use requires a commercial license from tdt@mimasu.nl.
 */
export interface TDTEngine {
  /**
   * Translate an EPC identifier between encoding levels.
   * @param epcIdentifier - The EPC to convert (binary, hex, URI, or legacy)
   * @param parameterList - Semicolon-delimited key=value pairs (e.g., "filter=3;tagLength=96")
   * @param outputFormat - Target format: BINARY, LEGACY, TAG_ENCODING, PURE_IDENTITY
   * @throws Error if translation fails
   */
  translate(epcIdentifier: string, parameterList: string, outputFormat: string): string;

  /**
   * Translate an EPC identifier without throwing exceptions.
   * @returns The translated value, or null if translation failed
   */
  tryTranslate(epcIdentifier: string, parameterList: string, outputFormat: string): string | null;

  /**
   * Translate an EPC identifier and return detailed results including all decoded fields.
   * @returns JSON object with output string and fields dictionary, or null if translation failed
   */
  translateDetails(epcIdentifier: string, parameterList: string, outputFormat: string): { output: string; fields: Record<string, string> } | null;

  /** Convert hexadecimal string to binary string */
  hexToBinary(hex: string): string;

  /** Convert binary string to hexadecimal string */
  binaryToHex(binary: string): string;

  /**
   * Get any errors encountered while loading scheme files.
   * Returns a newline-delimited string of error messages, or "" if none.
   */
  getLoadErrors(): string;
}

/**
 * Initialize the TDT WebAssembly engine.
 * Must be called before using any translation methods.
 * The WASM binary is loaded asynchronously.
 */
export function createEngine(): Promise<TDTEngine>;
