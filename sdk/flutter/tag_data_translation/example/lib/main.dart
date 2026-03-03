import 'package:flutter/material.dart';
import 'package:tag_data_translation/tag_data_translation.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'TDT Example',
      home: const TdtExample(),
    );
  }
}

class TdtExample extends StatefulWidget {
  const TdtExample({super.key});

  @override
  State<TdtExample> createState() => _TdtExampleState();
}

class _TdtExampleState extends State<TdtExample> {
  String _result = '';

  void _encode() {
    try {
      // convert hex EPC to binary
      final binary = TDTEngine.hexToBinary('30340242201d8840009efdf7');

      // translate to Pure Identity URI
      final uri = TDTEngine.translate(
        binary,
        'PURE_IDENTITY',
      );

      setState(() => _result = uri);
    } on TranslationError catch (e) {
      setState(() => _result = 'Error: $e');
    }
  }

  void _decode() {
    try {
      // translate a Pure Identity URI to Tag Encoding (hex)
      final hex = TDTEngine.translate(
        'urn:epc:id:sgtin:0037000.030241.10419703',
        'TAG_ENCODING',
        params: 'tagLength=96;filter=3',
      );

      setState(() => _result = hex);
    } on TranslationError catch (e) {
      setState(() => _result = 'Error: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('TDT Example')),
      body: Padding(
        padding: const EdgeInsets.all(24),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            ElevatedButton(
              onPressed: _encode,
              child: const Text('Decode EPC Hex'),
            ),
            const SizedBox(height: 12),
            ElevatedButton(
              onPressed: _decode,
              child: const Text('Encode SGTIN'),
            ),
            const SizedBox(height: 24),
            Text(
              _result.isEmpty ? 'Tap a button to translate' : _result,
              style: Theme.of(context).textTheme.bodyLarge,
            ),
          ],
        ),
      ),
    );
  }
}
