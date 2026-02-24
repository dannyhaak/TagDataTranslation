Pod::Spec.new do |s|
  s.name             = 'tag_data_translation'
  s.version          = '3.0.0'
  s.summary          = 'GS1 EPC Tag Data Translation for Flutter'
  s.description      = 'Encode and decode SGTIN, SSCC, SGLN, GRAI, and all EPC schemes on iOS.'
  s.homepage         = 'https://www.mimasu.nl'
  s.license          = { :type => 'BSL-1.1', :file => '../LICENSE' }
  s.author           = { 'Mimasu' => 'tdt@mimasu.nl' }
  s.source           = { :path => '.' }
  s.source_files     = 'Classes/**/*'
  s.dependency 'Flutter'
  s.platform         = :ios, '15.0'
  s.swift_version    = '5.0'

  # NativeAOT static library packaged as XCFramework
  s.vendored_frameworks = 'Frameworks/TagDataTranslation.xcframework'

  # Flutter.framework does not contain a i386 slice
  s.pod_target_xcconfig = { 'DEFINES_MODULE' => 'YES', 'EXCLUDED_ARCHS[sdk=iphonesimulator*]' => 'i386' }
end
